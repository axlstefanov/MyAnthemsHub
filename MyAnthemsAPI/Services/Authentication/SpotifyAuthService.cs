using MyAnthemsAPI.Models.Authentication;
using Newtonsoft.Json;
using System.Text;

namespace MyAnthemsAPI.Services.Authentication
{
    public class SpotifyAuthService(HttpClient httpClient) : ISpotifyAuthService
    {
        public async Task<string> GetAccessTokenAsync(string clientId, string clientSecret)
        {
            var authHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authHeader);

            var requestContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            var response = await httpClient.PostAsync("https://accounts.spotify.com/api/token", requestContent);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<SpotifyTokenResponse>(content);

            return tokenResponse.AccessToken;
        }
    }
}