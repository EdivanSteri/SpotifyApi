using SpotifyApi.BL.Interfaces;
using SpotifyApi.Models;
using System.Threading.Tasks;

namespace SpotifyApi.BL.Services
{
    public class SpotifyDataService : ISpotifyDataService
    {
        private readonly ISpotifyDataRepository _mySpotifyDataRepository;

        public SpotifyDataService(ISpotifyDataRepository mySpotifyDataRepository)
        {
            _mySpotifyDataRepository = mySpotifyDataRepository;
        }

        public async Task<GetArtistAlbums> GetArtistAlbumsByArtistIdService(string idArtist, string accessToken)
        {
            return await _mySpotifyDataRepository.GetArtistAlbumsByArtistIdRepository(idArtist, accessToken);
        }

        public async Task<GetAlbumByNameResponse> GetAlbumDataByAlbumNameService(string albumName, string accessToken)
        {
            return await _mySpotifyDataRepository.GetAlbumDataByAlbumNameRepository(albumName, accessToken);
        }

        public async Task<string> GetAlbumIdByAlbumNameService(string albumName, string accessToken)
        {
            return await _mySpotifyDataRepository.GetAlbumIdByAlbumNameRepository(albumName, accessToken);
        }

        public async Task<GetMyToArtists> GetArtistDataByArtistNameService(string artistName, string accessToken)
        {
            return await _mySpotifyDataRepository.GetArtistDataByArtistNameRepository(artistName, accessToken);
        }

        public async Task<GetArtistTopTracks> GetArtistTopTracksByArtistNameService(string artistName, string accessToken)
        {
            return await _mySpotifyDataRepository.GetArtistTopTracksByArtistNameRepository(artistName, accessToken);
        }

        public async Task<FetchProfileResponse> GetUserProfileDataService(string accessToken)
        {
            return await _mySpotifyDataRepository.GetUserProfileDataRepository(accessToken);
        }

        public async Task<GetMyToArtists> GetUserTopThreeArtistsLastMonthService(string accessToken)
        {
            return await _mySpotifyDataRepository.GetUserTopThreeArtistsLastMonthRepository(accessToken);
        }
        public async Task<GetMyTopTracks> GetUserTopFiftyTracksLastMonthService(string accessToken)
        {
            return await _mySpotifyDataRepository.GetUserTopFiftyTracksLastMonthRepository(accessToken);
        }
    }
}
