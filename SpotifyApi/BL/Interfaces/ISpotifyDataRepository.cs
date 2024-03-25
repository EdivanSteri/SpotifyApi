using SpotifyApi.Models;
using System.Threading.Tasks;

namespace SpotifyApi.BL.Interfaces
{
    public interface ISpotifyDataRepository
    {
        public Task<GetArtistAlbums> GetArtistAlbumsByArtistIdRepository(string idArtist, string accessToken);
        public Task<string> GetAlbumIdByAlbumNameRepository(string albumName, string accessToken);
        public Task<GetAlbumByNameResponse> GetAlbumDataByAlbumNameRepository(string albumName, string accessToken);
        public Task<GetMyToArtists> GetArtistDataByArtistNameRepository(string artistName, string accessToken);
        public Task<GetArtistTopTracks> GetArtistTopTracksByArtistNameRepository(string artistName, string accessToken);
        public Task<FetchProfileResponse> GetUserProfileDataRepository(string token);
        public Task<GetMyToArtists> GetUserTopThreeArtistsLastMonthRepository(string accessToken);
        public Task<GetMyTopTracks> GetUserTopFiftyTracksLastMonthRepository(string accessToken);
    }
}
