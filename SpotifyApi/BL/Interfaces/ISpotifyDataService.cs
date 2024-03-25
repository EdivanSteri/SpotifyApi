using SpotifyApi.Models;
using System.Threading.Tasks;

namespace SpotifyApi.BL.Interfaces
{
    public interface ISpotifyDataService
    {
        public Task<GetArtistAlbums> GetArtistAlbumsByArtistIdService(string idArtist, string accessToken);
        public Task<GetAlbumByNameResponse> GetAlbumDataByAlbumNameService(string albumName, string accessToken);
        public Task<string> GetAlbumIdByAlbumNameService(string albumName, string accessToken);
        public Task<GetMyToArtists> GetArtistDataByArtistNameService(string artistName, string accessToken);
        public Task<GetArtistTopTracks> GetArtistTopTracksByArtistNameService(string artistName, string accessToken);
        public Task<GetMyToArtists> GetUserTopThreeArtistsLastMonthService(string accessToken);
        public Task<GetMyTopTracks> GetUserTopFiftyTracksLastMonthService(string accessToken);
        public Task<FetchProfileResponse> GetUserProfileDataService(string accessToken);
    }
}
