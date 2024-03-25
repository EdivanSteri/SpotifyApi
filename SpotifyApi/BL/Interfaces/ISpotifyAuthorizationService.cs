using SpotifyApi.Models;
using System.Threading.Tasks;

namespace SpotifyApi.BL.Interfaces
{
    public interface ISpotifyAuthorizationService
    {
        public Task<string> GetAccessTokenClientCredentialsService(GetAccessTokenRequest req);
        public Task<string> GetAccessTokenNextToAuthorizationService(string clientId, string code, string verifier);
        public SpotifyOauth GetSpotifyOauthService();
    }
}
