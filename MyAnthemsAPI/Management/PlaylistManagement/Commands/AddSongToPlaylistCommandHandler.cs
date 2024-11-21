using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;

namespace MyAnthemsAPI.Management.PlaylistManagement.Commands
{
    public class AddSongToPlaylistCommandHandler(AppDbContext context) : IRequestHandler<AddSongToPlaylistCommand, bool>
    {
        public async Task<bool> Handle(AddSongToPlaylistCommand command, CancellationToken cancellationToken)
        {
            var playlist = await context.Playlists
                .Include(p => p.Songs)
                .SingleOrDefaultAsync(p => p.Id == command.Id, cancellationToken);
            if (playlist == null)
                return false;

            var song = await context.Songs.FirstOrDefaultAsync(s => s.Id == command.SongId, cancellationToken);
            if (song == null)
                return false;

            if (!playlist.Songs.Contains(song))
            {
                playlist.Songs.Add(song);
                await context.SaveChangesAsync(cancellationToken);
            }

            return true;
        }
    }
}