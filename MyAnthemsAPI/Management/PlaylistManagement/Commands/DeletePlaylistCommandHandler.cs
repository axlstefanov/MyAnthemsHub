using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;

namespace MyAnthemsAPI.Management.PlaylistManagement.Commands
{
    public class DeletePlaylistCommandHandler(AppDbContext context) : IRequestHandler<DeletePlaylistCommand>
    {
        public async Task Handle(DeletePlaylistCommand command, CancellationToken cancellationToken)
        {
            var foundPlaylist = await context.Playlists.SingleAsync(x => x.Id == command.Id, cancellationToken);
            context.Playlists.Remove(foundPlaylist);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}