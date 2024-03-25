using SpotifyApi.Models;
using System.Threading.Tasks;

namespace SpotifyApi.BL.Interfaces
{
    public interface ISpotifyAuthorizationRepository
    {
        public Task<string> GetAccessTokenClientCredentialsService(GetAccessTokenRequest req);
        public Task<string> GetAccessTokenNextToAuthorizationRepository(string clientId, string code, string verifier);
        public SpotifyOauth GetSpotifyOauthRepository();
    }
}
