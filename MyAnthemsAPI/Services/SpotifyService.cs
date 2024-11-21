using MyAnthemsAPI.Models.Authentication;
using MyAnthemsAPI.Models.SongManagement;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MyAnthemsAPI.Services
{
    public class SpotifyService(HttpClient httpClient, IConfiguration configuration) : ISpotifyService
    {
        public async Task<List<Song>> SearchTracksAsync(string query)
        {
            var token = await GetSpotifyAccessTokenAsync();

            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await httpClient.GetAsync(
                $"https://api.spotify.com/v1/search?q={Uri.EscapeDataString(query)}&type=track");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<SpotifySearchResult>(content);
            return searchResult.Tracks.Items.Select(track => new Song
            {
                Id = track.Id,
                Title = track.Name,
                Artist = track.Artists.FirstOrDefault()?.Name,
                Album = track.Album.Name,
                Duration = TimeSpan.FromMilliseconds(track.DurationMs)
            }).ToList();
        }

        private async Task<string> GetSpotifyAccessTokenAsync()
        {
            var clientId = configuration["Spotify:ClientId"];
            var clientSecret = configuration["Spotify:ClientSecret"];

            var tokenUrl = "https://accounts.spotify.com/api/token";
            var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenUrl);

            tokenRequest.Content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials"),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret)
            });

            var tokenResponse = await httpClient.SendAsync(tokenRequest);
            tokenResponse.EnsureSuccessStatusCode();

            var tokenContent = await tokenResponse.Content.ReadAsStringAsync();
            var tokenResult = JsonConvert.DeserializeObject<SpotifyTokenResponse>(tokenContent);

            return tokenResult.AccessToken;
        }
    }

    public class SpotifySearchResult
    {
        [JsonProperty("tracks")]
        public SpotifyTracks Tracks { get; set; }
    }

    public class SpotifyTracks
    {
        [JsonProperty("items")]
        public List<SpotifyTrackItem> Items { get; set; }
    }

    public class SpotifyTrackItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("artists")]
        public List<SpotifyArtist> Artists { get; set; }

        [JsonProperty("album")]
        public SpotifyAlbum Album { get; set; }

        [JsonProperty("duration_ms")]
        public int DurationMs { get; set; }
    }

    public class SpotifyArtist
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class SpotifyAlbum
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}