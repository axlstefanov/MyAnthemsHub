using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAnthemsAPI.Management.PlaylistManagement.Commands;
using MyAnthemsAPI.Management.PlaylistManagement.Queries;
using MyAnthemsAPI.Management.UserManagement.Queries;

namespace MyAnthemsAPI.Controllers
{
    public class PlaylistController(ISender mediatr) : GenericController
    {
        [HttpPost("Add")]
        public async Task<IResult> Add([FromBody] CreatePlaylistCommand command)
        {
            var id = await mediatr.Send(command);
            if (Guid.Empty == id)
            {
                return Results.BadRequest();
            }

            return Results.Created($"/Playlist/{id}", new { id });
        }

        [HttpGet("{id:guid}")]
        public async Task<IResult> Get(Guid id)
        {
            var playlist = await mediatr.Send(new GetUserQuery(id));
            return Results.Ok(playlist);
        }

        //[HttpPost]
        //public async Task<IResult> GetByUserId(Guid id)
        //{
        //    var playlist = await mediatr.Send(new ListPlaylistQuery(id));
        //    return Results.Ok(playlist);
        //}

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var playlist = await mediatr.Send(new ListPlaylistQuery());
            return Results.Ok(playlist);
        }
    }
}