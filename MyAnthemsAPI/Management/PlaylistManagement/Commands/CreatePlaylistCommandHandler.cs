using MediatR;
using MyAnthemsAPI.Data;
using MyAnthemsAPI.Models.PlaylistManagement;

namespace MyAnthemsAPI.Management.PlaylistManagement.Commands
{
    public class CreatePlaylistCommandHandler(AppDbContext context) : IRequestHandler<CreatePlaylistCommand, Guid>
    {
        public async Task<Guid> Handle(CreatePlaylistCommand command, CancellationToken cancellationToken)
        {
            var newPlaylist = new Playlist
            {
                Title = command.Title,
                IsPublic = command.IsPublic,
                UserId = command.UserId
            };

            context.Playlists.Add(newPlaylist);
            await context.SaveChangesAsync(cancellationToken);
            return newPlaylist.Id;
        }
    }
}