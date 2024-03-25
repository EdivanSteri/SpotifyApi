using System.Collections.Generic;
using static SpotifyApi.Models.CommonResponse;

namespace SpotifyApi.Models
{
    public class GetArtistTopTracks
    {
        public List<Track> tracks { get; set; }
    }    
}
