using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SpotifyApi.BL.Interfaces;
using SpotifyApi.Models;
using System.Threading.Tasks;

namespace SpotifyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyAuthorizationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ISpotifyAuthorizationService _spotifyOauthService;

        public SpotifyAuthorizationController(IConfiguration configuration, ISpotifyAuthorizationService spotifyOauthService)
        {
            _configuration = configuration;
            _spotifyOauthService = spotifyOauthService;
        }

        [HttpGet]
        [Route("GetSpotifyOauthToAuthorization")]
        public ActionResult<SpotifyOauth> GetSpotifyOauth()
        {
            var ret = _spotifyOauthService.GetSpotifyOauthService();

            return Ok(ret);
        }

        [HttpGet]
        [Route("GetAccessTokeNextToAuthorization")]
        public async Task<ActionResult<string>> GetAccessTokenNextToAuthorization([FromQuery] string code, [FromQuery] string verifier)
        {
            var ret = await _spotifyOauthService.GetAccessTokenNextToAuthorizationService(_configuration["Spotify:ClientId"], code, verifier);
            return Ok(ret);
        }

        [HttpGet]
        [Route("GetAccessToken")]
        public async Task<ActionResult<string>> GetAccessToken()
        {
            var req = new GetAccessTokenRequest { ClientId = _configuration["Spotify:ClientId"], ClientSecret = _configuration["Spotify:ClientSecret"] };
            var ret = await _spotifyOauthService.GetAccessTokenClientCredentialsService(req);
            return Ok(ret);
        }
    }
}
