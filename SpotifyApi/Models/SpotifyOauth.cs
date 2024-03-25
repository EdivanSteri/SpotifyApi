namespace SpotifyApi.Models
{
    public class SpotifyOauth
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Verifier { get; set; }
        public string Code { get; set; }
        public string AuthorizationUrl { get; set; }
    }
}
