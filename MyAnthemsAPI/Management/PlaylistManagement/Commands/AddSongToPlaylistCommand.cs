using MediatR;

namespace MyAnthemsAPI.Management.PlaylistManagement.Commands
{
    public record AddSongToPlaylistCommand(Guid Id, string SongId) : IRequest<bool>;
}
