using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SpotifyApi.Common
{
    public static class Utils
    {
        public static string GenerateVerifier(int length)
        {
            var random = new Random();
            const string possibleChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var codeVerifier = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                codeVerifier.Append(possibleChars[random.Next(possibleChars.Length)]);
            }

            return codeVerifier.ToString();
        }

        public static string GenerateCodeChallenge(string verifier)
        {
            var data = Encoding.UTF8.GetBytes(verifier);
            var digest = SHA256.HashData(data);
            var base64Challenge = Convert.ToBase64String(digest)
                .Replace('+', '-')
                .Replace('/', '_')
                .TrimEnd('=');

            return base64Challenge;
        }

        public static string ToQueryString(Dictionary<string, string> queryParams)
        {
            return string.Join("&", queryParams.Select(kvp => $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value)}"));
        }
    }
}
