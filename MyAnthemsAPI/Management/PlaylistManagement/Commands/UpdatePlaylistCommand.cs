using MediatR;

namespace MyAnthemsAPI.Management.PlaylistManagement.Commands
{
    public record UpdatePlaylistCommand(Guid Id, string Title, bool IsPublic) : IRequest;
}