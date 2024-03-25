using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SpotifyApi.BL.Interfaces;
using SpotifyApi.Common;
using SpotifyApi.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyApi.Repository
{
    public class SpotifyAuthorizationRepository : ISpotifyAuthorizationRepository
    {
        private readonly IConfiguration _configuration;
        public SpotifyAuthorizationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetAccessTokenClientCredentialsService(GetAccessTokenRequest req)
        {
            using HttpClient client = new();
            // Imposta le credenziali client per l'autenticazione
            string credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{req.ClientId}:{req.ClientSecret}"));
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {credentials}");

            // Genera i parametri per la richiesta di token
            var tokenParams = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" },
            };

            // Effettua la richiesta di token
            var requestUrl = "https://accounts.spotify.com/api/token";

            HttpResponseMessage tokenResponse = await client.PostAsync(requestUrl, new FormUrlEncodedContent(tokenParams));

            if (tokenResponse.IsSuccessStatusCode)
            {
                // Leggi la risposta come stringa
                string tokenResponseString = await tokenResponse.Content.ReadAsStringAsync();

                // Analizza la risposta JSON per ottenere il token di accesso
                dynamic tokenResult = JsonConvert.DeserializeObject(tokenResponseString);
                string accessToken = tokenResult.access_token;

                return accessToken;
            }
            else
            {
                Console.WriteLine($"Errore: {tokenResponse.StatusCode}");
                return null;
            }
        }

        public async Task<string> GetAccessTokenNextToAuthorizationRepository(string clientId, string code, string verifier)
        {
            //creazione req per la chiamata api
            var requestBody = new Dictionary<string, string>
            {
                { "client_id", clientId },
                { "grant_type", "authorization_code" },
                { "code", code },
                { "redirect_uri", _configuration["Spotify:RedirectUri"] },
                { "code_verifier", verifier },
            };

            using var client = new HttpClient();
            var result = await client.PostAsync("https://accounts.spotify.com/api/token", new FormUrlEncodedContent(requestBody));
            var responseJson = await result.Content.ReadAsStringAsync();

            // Analizza la risposta JSON per ottenere il token di accesso
            dynamic tokenResult = JsonConvert.DeserializeObject(responseJson);
            string accessToken = tokenResult.access_token;

            return accessToken;
        }

        public SpotifyOauth GetSpotifyOauthRepository()
        {
            var verifier = Utils.GenerateVerifier(128);
            var challenge = Utils.GenerateCodeChallenge(verifier);

            var queryParams = new Dictionary<string, string>
            {
                { "client_id", _configuration["Spotify:ClientId"] },
                { "response_type", "code" },
                { "redirect_uri", _configuration["Spotify:RedirectUri"] },
                { "scope", _configuration["Spotify:Scope"] },
                { "code_challenge_method", "S256" },
                { "code_challenge", challenge }
            };

            var authorizationUrl = $"https://accounts.spotify.com/authorize?{Utils.ToQueryString(queryParams)}";

            return new SpotifyOauth { AuthorizationUrl = authorizationUrl, ClientId = _configuration["Spotify:ClientId"], ClientSecret = _configuration["Spotify:ClientSecret"], Verifier = verifier };
        }
    }
}
