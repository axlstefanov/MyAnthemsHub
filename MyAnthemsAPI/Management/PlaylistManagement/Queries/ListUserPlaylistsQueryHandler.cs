using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;
using MyAnthemsAPI.Management.PlaylistManagement.Dtos;

namespace MyAnthemsAPI.Management.PlaylistManagement.Queries
{
    public class ListUserPlaylistsQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<ListUserPlaylistsQuery, List<PlaylistDto>>
    {
        public async Task<List<PlaylistDto>> Handle(ListUserPlaylistsQuery request, CancellationToken cancellationToken)
        {
            var playlists = await context.Playlists
                .Where(p => p.UserId == request.UserId)
                .ToListAsync(cancellationToken);

            return mapper.Map<List<PlaylistDto>>(playlists);
        }
    }
}