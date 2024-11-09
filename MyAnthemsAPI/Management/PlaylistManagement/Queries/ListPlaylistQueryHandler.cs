using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;
using MyAnthemsAPI.Management.PlaylistManagement.Dtos;

namespace MyAnthemsAPI.Management.PlaylistManagement.Queries
{
    public class ListPlaylistQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<ListPlaylistQuery, List<PlaylistDto>>
    {
        public async Task<List<PlaylistDto>> Handle(ListPlaylistQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Playlists.ToListAsync(cancellationToken);
            List<PlaylistDto> list = mapper.Map<List<PlaylistDto>>(result);

            return list;
        }
    }
}