using SpotifyApi.BL.Interfaces;
using SpotifyApi.Models;
using System.Threading.Tasks;

namespace SpotifyApi.BL.Services
{
    public class SpotifyAuthorizationService : ISpotifyAuthorizationService
    {
        private readonly ISpotifyAuthorizationRepository _spotifyOauthRepository;

        public SpotifyAuthorizationService(ISpotifyAuthorizationRepository spotifyOauthRepository)
        {
            _spotifyOauthRepository = spotifyOauthRepository;
        }

        public async Task<string> GetAccessTokenClientCredentialsService(GetAccessTokenRequest req)
        {
            return await _spotifyOauthRepository.GetAccessTokenClientCredentialsService(req);
        }

        public async Task<string> GetAccessTokenNextToAuthorizationService(string clientId, string code, string verifier)
        {
            return await _spotifyOauthRepository.GetAccessTokenNextToAuthorizationRepository(clientId, code, verifier);
        }

        public SpotifyOauth GetSpotifyOauthService()
        {
            return _spotifyOauthRepository.GetSpotifyOauthRepository();
        }
    }
}
