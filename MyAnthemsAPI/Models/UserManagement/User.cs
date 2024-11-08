using MyAnthemsAPI.Models.PlaylistManagement;

namespace MyAnthemsAPI.Models.UserManagement
{
    public class User : DefaultEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<Playlist> Playlists { get; set; }
    }
}
