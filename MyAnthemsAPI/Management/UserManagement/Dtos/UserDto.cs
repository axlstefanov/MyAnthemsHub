using MyAnthemsAPI.Models.PlaylistManagement;

namespace MyAnthemsAPI.Management.UserManagement.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Playlist>? Playlists { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}