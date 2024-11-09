using MyAnthemsAPI.Models.SongManagement;

namespace MyAnthemsAPI.Management.PlaylistManagement.Dtos
{
    public class PlaylistDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsPublic { get; set; }
        public List<Song>? Songs { get; set; }
        public Guid UserId { get; set; }
    }
}