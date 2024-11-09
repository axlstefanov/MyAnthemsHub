using MediatR;

namespace MyAnthemsAPI.Management.PlaylistManagement.Commands
{
    public record CreatePlaylistCommand() : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsPublic { get; set; }
    }
}