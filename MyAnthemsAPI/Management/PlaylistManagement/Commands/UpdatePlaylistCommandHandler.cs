using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;

namespace MyAnthemsAPI.Management.PlaylistManagement.Commands
{
    public class UpdatePlaylistCommandHandler(AppDbContext context) : IRequestHandler<UpdatePlaylistCommand>
    {
        public async Task Handle(UpdatePlaylistCommand command, CancellationToken cancellation)
        {
            var foundUser = await context.Playlists.SingleAsync(p => p.Id == command.Id, cancellation);
            foundUser.Title = command.Title;
            foundUser.IsPublic = command.IsPublic;
            await context.SaveChangesAsync(cancellation);
        }
    }
}