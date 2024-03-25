using Newtonsoft.Json;
using SpotifyApi.BL.Interfaces;
using SpotifyApi.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SpotifyApi.Repository
{
    public class SpotifyDataRepository : ISpotifyDataRepository
    {
        private readonly string _spotifyBaseUrl;
        private readonly string access_token;

        public SpotifyDataRepository()
        {
            _spotifyBaseUrl = "https://api.spotify.com/";
        }

        /*
         * Parameter: artistId, accessToken
         * Returns the albums of an artist by passing its id
         */
        public async Task<GetArtistAlbums> GetArtistAlbumsByArtistIdRepository(string artistId, string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                if (!string.IsNullOrEmpty(artistId))
                {
                    using HttpClient client = new();
                    // Imposta l'intestazione di autorizzazione con il token di accesso
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                    // Effettua la chiamata GET per ottenere l'album
                    var requesturl = $"https://api.spotify.com/v1/artists/{artistId}/albums/";
                    HttpResponseMessage response = await client.GetAsync(requesturl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Leggi la risposta come stringa
                        var responseAsString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetArtistAlbums>(responseAsString);
                    }
                    else
                    {
                        Console.WriteLine($"Errore: {response.StatusCode}");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Album non trovato.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Access Token non valido.");
                return null;
            }

        }
       
        /**
         * Parameter: albumName, accessToken
         * Returns data of a album passing its name
         */
        public async Task<GetAlbumByNameResponse> GetAlbumDataByAlbumNameRepository(string albumName, string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                //Get Album Id
                string albumId = await GetAlbumIdByAlbumNameRepository(albumName, accessToken);

                if (!string.IsNullOrEmpty(albumId))
                {
                    using HttpClient client = new();
                    // Imposta l'intestazione di autorizzazione con il token di accesso
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                    // Effettua la chiamata GET per ottenere l'album
                    var requesturl = $"https://api.spotify.com/v1/albums/{albumId}";
                    HttpResponseMessage response = await client.GetAsync(requesturl);

                    if (response.IsSuccessStatusCode)
                    {
                        // Leggi la risposta come stringa
                        var responseAsString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetAlbumByNameResponse>(responseAsString);
                    }
                    else
                    {
                        Console.WriteLine($"Errore: {response.StatusCode}");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Album non trovato.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Access Token non valido.");
                return null;
            }
        }

        /**
         * Parameter: albumName, accessToken
         * Returns the id of an album by passing its name
         * */
        public async Task<string> GetAlbumIdByAlbumNameRepository(string albumName, string accessToken)
        {
            using HttpClient client = new();
            // Imposta l'intestazione di autorizzazione con il token di accesso
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            // Effettua la chiamata GET per cercare l'album
            var requestUrl = $"https://api.spotify.com/v1/search?type=album&q={Uri.EscapeDataString(albumName)}";
            HttpResponseMessage response = await client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                // Leggi la risposta come stringa
                string responseBody = await response.Content.ReadAsStringAsync();

                // Analizza la risposta JSON per ottenere l'ID dell'album
                dynamic searchResult = JsonConvert.DeserializeObject(responseBody);
                string albumId = searchResult.albums.items[0].id;

                return albumId;
            }
            else
            {
                Console.WriteLine($"Errore: {response.StatusCode}");
                return null;
            }
        }

        /*
         * Parameter: artistName, accessToken
         * Returns Id of an Artist passing its Name
         */
        public async Task<string> GetArtistIdByArtistNameRepository(string artistName, string accessToken)
        {
            using HttpClient client = new();
            // Imposta l'intestazione di autorizzazione con il token di accesso
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

            // Effettua la chiamata GET per cercare l'album
            var requestUrl = $"https://api.spotify.com/v1/search?type=artist&q={Uri.EscapeDataString(artistName)}";
            HttpResponseMessage response = await client.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                // Leggi la risposta come stringa
                string responseBody = await response.Content.ReadAsStringAsync();

                // Analizza la risposta JSON per ottenere l'ID dell'album
                dynamic searchResult = JsonConvert.DeserializeObject(responseBody);
                string artistId = searchResult.artists.items[0].id;

                return artistId;
            }
            else
            {
                Console.WriteLine($"Errore: {response.StatusCode}");
                return null;
            }
        }

        /**
         * Parameter: artistName, accessToken
         * Returns data of an artist passing its name
         */
        public async Task<GetMyToArtists> GetArtistDataByArtistNameRepository(string artistName, string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                //Get artistId
                string artistId = await GetArtistIdByArtistNameRepository(artistName, accessToken);

                if (!string.IsNullOrEmpty(artistId))
                {
                    using HttpClient client = new();
                    // Imposta l'intestazione di autorizzazione con il token di accesso
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                    // Effettua la chiamata GET per ottenere l'album
                    var requesturl = $"https://api.spotify.com/v1/artists/{artistId}";
                    HttpResponseMessage response = await client.GetAsync(requesturl);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseAsString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetMyToArtists>(responseAsString);
                    }
                    else
                    {
                        Console.WriteLine($"Errore: {response.StatusCode}");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Artista non trovato.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Access Token non valido.");
                return null;
            }
        }

        /*
         * Parameter: artistName, accessToken, market(its the simbol of a country, example for italy is IT, not is mandatory)
         * Returns top tracks of an artist passing its name
         */
        public async Task<GetArtistTopTracks> GetArtistTopTracksByArtistNameRepository(string artistName, string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                //Get ArtistId
                string artistId = await GetArtistIdByArtistNameRepository(artistName, accessToken);

                if (!string.IsNullOrEmpty(artistId))
                {
                    using HttpClient client = new();
                    // Imposta l'intestazione di autorizzazione con il token di accesso
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");


                    // Effettua la chiamata GET per ottenere l'album
                    var requesturl = $"https://api.spotify.com/v1/artists/{artistId}/top-tracks?market=IT";

                    HttpResponseMessage response = await client.GetAsync(requesturl);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseAsString = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<GetArtistTopTracks>(responseAsString); ;
                    }
                    else
                    {
                        Console.WriteLine($"Errore: {response.StatusCode}");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Tracce non trovate.");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Access Token non valido.");
                return null;
            }
        }

        /*
         * Parameter: accessToken
         * Returns top 3 artist of a User in the last month
         */
        public async Task<GetMyToArtists> GetUserTopThreeArtistsLastMonthRepository(string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                // Configura l'endpoint e gli header della richiesta
                var endpoint = $"https://api.spotify.com/v1/me/top/artists?time_range=short_term&limit=3";

                using HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                // Esegui la richiesta GET all'API di Spotify
                var response = await client.GetAsync(endpoint);

                // Gestisci la risposta
                if (response.IsSuccessStatusCode)
                {
                    // Deserializza la risposta in oggetti SpotifyTopItem
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetMyToArtists>(content);
                }
                else
                {
                    Console.WriteLine($"Errore: {response.StatusCode}");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Access Token non valido.");
                return null;
            }
        }

        /*
         * Parameter: accessToken
         * Returns top 50 tracks of a User in the last month
         */
        public async Task<GetMyTopTracks> GetUserTopFiftyTracksLastMonthRepository(string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                // Configura l'endpoint e gli header della richiesta
                var endpoint = $"https://api.spotify.com/v1/me/top/tracks?time_range=short_term&limit=50";

                using HttpClient client = new();
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                // Esegui la richiesta GET all'API di Spotify
                var response = await client.GetAsync(endpoint);

                // Gestisci la risposta
                if (response.IsSuccessStatusCode)
                {
                    // Deserializza la risposta in oggetti SpotifyTopItem
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GetMyTopTracks>(content);
                }
                else
                {
                    Console.WriteLine($"Errore: {response.StatusCode}");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Access Token non valido.");
                return null;
            }
        }

        /**
         * Parameter: accessToken
         * Returns the data of the profile of a User
         */
        public async Task<FetchProfileResponse> GetUserProfileDataRepository(string accessToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
            var result = await client.GetAsync("https://api.spotify.com/v1/me");
            var responseJson = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FetchProfileResponse>(responseJson);
        }
    }
}
