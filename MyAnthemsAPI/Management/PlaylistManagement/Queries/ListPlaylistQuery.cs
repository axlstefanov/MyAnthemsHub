using MediatR;
using MyAnthemsAPI.Management.PlaylistManagement.Dtos;

namespace MyAnthemsAPI.Management.PlaylistManagement.Queries
{
    public record ListPlaylistQuery() : IRequest<List<PlaylistDto>>;
}