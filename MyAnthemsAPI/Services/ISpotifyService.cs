using MyAnthemsAPI.Models.SongManagement;

namespace MyAnthemsAPI.Services
{
    public interface ISpotifyService
    {
        Task<List<Song>> SearchTracksAsync(string query);
    }
}