using MediatR;

namespace MyAnthemsAPI.Management.PlaylistManagement.Commands
{
    public record DeletePlaylistCommand(Guid Id) : IRequest;
}