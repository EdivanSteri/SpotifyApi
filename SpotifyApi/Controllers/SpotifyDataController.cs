using Microsoft.AspNetCore.Mvc;
using SpotifyApi.BL.Interfaces;
using SpotifyApi.Models;
using System.Threading.Tasks;

namespace SpotifyApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyDataController : ControllerBase
    {
        private readonly ISpotifyDataService _mySpotifyDataService;

        public SpotifyDataController(ISpotifyDataService mySpotifyDataService)
        {
            _mySpotifyDataService = mySpotifyDataService;
        }

        /**
         * Parameter: artistId, accessToken
         * Returns the id of an album by passing its name
         * */
        [HttpGet]
        [Route("GetArtistAlbumsByArtistId")]
        public async Task<ActionResult<GetAlbumByNameResponse>> GetArtistAlbumsByArtistId([FromQuery] string artistId, [FromQuery] string accessToken)
        {
            var ret = await _mySpotifyDataService.GetArtistAlbumsByArtistIdService(artistId, accessToken);
            return Ok(ret);
        }

        /**
         * Parameter: albumName, accessToken
         * Returns the id of an album by passing its name
         * */
        [HttpGet]
        [Route("GetAlbumDataByAlbumName")]
        public async Task<ActionResult<GetAlbumByNameResponse>> GetAlbumDataByAlbumName([FromQuery] string albumName, [FromQuery] string accessToken)
        {
            var ret = await _mySpotifyDataService.GetAlbumDataByAlbumNameService(albumName, accessToken);
            return Ok(ret);
        }

        /**
         * Parameter: albumName, accessToken
         * Returns the id of an album by passing its name
         * */
        [HttpGet]
        [Route("GetAlbumIdByAlbumName")]
        public async Task<ActionResult<string>> GetAlbumIdByAlbumName([FromQuery] string albumName, [FromQuery] string accessToken)
        {
            var ret = await _mySpotifyDataService.GetAlbumIdByAlbumNameService(albumName, accessToken);
            return Ok(ret);
        }

        /**
         * Parameter: artistName, accessToken
         * Returns the top tracks of an artist by passing its name
         * */
        [HttpGet]
        [Route("GetArtistTopTracksByArtistName")]
        public async Task<ActionResult<GetArtistTopTracks>> GetArtistTopTracksByArtistName([FromQuery] string artistName, [FromQuery] string accessToken)
        {
            var ret = await _mySpotifyDataService.GetArtistTopTracksByArtistNameService(artistName, accessToken);
            return Ok(ret);
        }

        /**
         * Parameter: artistName, accessToken
         * Returns the data of an artist by passing its name
         * */
        [HttpGet]
        [Route("GetArtistDataByArtistName")]
        public async Task<ActionResult<GetMyToArtists>> GetArtistDataByArtistName([FromQuery] string artistName, [FromQuery] string accessToken)
        {
            var ret = await _mySpotifyDataService.GetArtistDataByArtistNameService(artistName, accessToken);
            return Ok(ret);
        }

        /**
         * Parameter: accessToken
         * Returns the top 3 top artists of an User
         * */
        [HttpGet]
        [Route("GetUserTopThreeArtistsLastMonth")]
        public async Task<ActionResult<GetMyToArtists>> GetUserTopThreeArtistsLastMonth([FromQuery] string accessToken)
        {
            var ret = await _mySpotifyDataService.GetUserTopThreeArtistsLastMonthService(accessToken);
            return Ok(ret);
        }

        /*
         * Parameter: accessToken
         * Returns top 50 tracks of a User in the last month
         */
        [HttpGet]
        [Route("GetUserTopFiftyTracksLastMonth")]
        public async Task<ActionResult<GetMyTopTracks>> GetUserTopFiftyTracksLastMonth([FromQuery] string accessToken)
        {
            var ret = await _mySpotifyDataService.GetUserTopFiftyTracksLastMonthService(accessToken);
            return Ok(ret);
        }

        /**
         * Parameter: accessToken
         * Returns the data of the profile of a User
         * */
        [HttpGet]
        [Route("GetUserProfileData")]
        public async Task<ActionResult<FetchProfileResponse>> GetUserProfileData(string token)
        {
            var ret = await _mySpotifyDataService.GetUserProfileDataService(token);
            return Ok(ret);
        }
    } 
}
