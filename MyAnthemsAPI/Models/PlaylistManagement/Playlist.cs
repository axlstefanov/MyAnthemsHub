using MyAnthemsAPI.Models.SongManagement;
using MyAnthemsAPI.Models.UserManagement;

namespace MyAnthemsAPI.Models.PlaylistManagement
{
    public class Playlist : DefaultEntity
    {
        public string Title { get; set; }
        public bool IsPublic { get; set; }
        public List<Song> Songs { get; set; }
        public User User { get; internal set; }
        public Guid UserId { get; internal set; }

        public List<PlaylistSong> PlaylistSongs { get; set; }
    }
}