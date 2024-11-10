using MyAnthemsAPI.Models.SongManagement;

namespace MyAnthemsAPI.Models.PlaylistManagement
{
    public class Playlist : DefaultEntity
    {
        public string Title { get; set; } = string.Empty;
        public bool IsPublic { get; set; }
        public List<Song>? Songs { get; set; }
        public Guid UserId { get; set; }

        public List<PlaylistSong>? PlaylistSongs { get; set; }
    }
}