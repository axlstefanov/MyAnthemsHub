namespace MyAnthemsAPI.Services.Authentication
{
    public interface ISpotifyAuthService
    {
        Task<string> GetAccessTokenAsync(string clientId, string clientSecret);
    }
}