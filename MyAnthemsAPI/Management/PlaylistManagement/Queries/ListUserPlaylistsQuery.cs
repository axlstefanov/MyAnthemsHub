using MediatR;
using MyAnthemsAPI.Management.PlaylistManagement.Dtos;

namespace MyAnthemsAPI.Management.PlaylistManagement.Queries
{
    public record ListUserPlaylistsQuery(Guid UserId) : IRequest<List<PlaylistDto>>;
}