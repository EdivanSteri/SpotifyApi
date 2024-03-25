using System.Collections.Generic;
using static SpotifyApi.Models.CommonResponse;

namespace SpotifyApi.Models
{
    public class ArtistItem
    {
        public ExternalUrls external_urls { get; set; }
        public Followers followers { get; set; }
        public List<string> genres { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public List<Image> images { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }
    public class GetMyToArtists
    {
        public List<ArtistItem> items { get; set; }
        public int total { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public string href { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
    }
}
