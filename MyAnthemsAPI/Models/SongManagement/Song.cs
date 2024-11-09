using MyAnthemsAPI.Models.PlaylistManagement;

namespace MyAnthemsAPI.Models.SongManagement
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Spotifylink { get; set; } = string.Empty;

        public List<PlaylistSong>? PlaylistSongs { get; set; }
    }
}