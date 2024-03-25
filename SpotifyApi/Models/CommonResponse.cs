using System.Collections.Generic;

namespace SpotifyApi.Models
{
    public class CommonResponse
    {
        public class Album
        {
            public string album_type { get; set; }
            public List<Artist> artists { get; set; }
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public List<Image> images { get; set; }
            public bool is_playable { get; set; }
            public string name { get; set; }
            public string release_date { get; set; }
            public string release_date_precision { get; set; }
            public double total_tracks { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class Artist
        {
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        public class ExternalIds
        {
            public string isrc { get; set; }
        }

        public class ExternalUrls
        {
            public string spotify { get; set; }
        }

        public class Image
        {
            public string url { get; set; }
            public double width { get; set; }
            public double height { get; set; }
        }

        public class Track
        {
            public Album album { get; set; }
            public List<Artist> artists { get; set; }
            public double disc_number { get; set; }
            public double duration_ms { get; set; }
            public bool @explicit { get; set; }
            public ExternalIds external_ids { get; set; }
            public ExternalUrls external_urls { get; set; }
            public string href { get; set; }
            public string id { get; set; }
            public bool is_local { get; set; }
            public bool is_playable { get; set; }
            public string name { get; set; }
            public double popularity { get; set; }
            public string preview_url { get; set; }
            public double track_number { get; set; }
            public string type { get; set; }
            public string uri { get; set; }
        }

        
        public class Copyright
        {
            public string text { get; set; }
            public string type { get; set; }
        }

        public class Followers
        {
            public object Href { get; set; }
            public int Total { get; set; }
        }
    }
}
