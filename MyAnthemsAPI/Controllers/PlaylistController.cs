﻿using MediatR;
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

        [HttpGet("User/{userId:guid}")]
        public async Task<IResult> GetByUserId(Guid userId)
        {
            var playlists = await mediatr.Send(new ListUserPlaylistsQuery(userId));
            return Results.Ok(playlists);
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var playlist = await mediatr.Send(new ListPlaylistQuery());
            return Results.Ok(playlist);
        }

        [HttpPut("{id:guid}")]
        public async Task<IResult> Update(Guid id, UpdatePlaylistCommand command)
        {
            if (id != command.Id)
                return Results.BadRequest();

            await mediatr.Send(command);
            return Results.NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IResult> Delete(Guid id)
        {
            await mediatr.Send(new DeletePlaylistCommand(id));
            return Results.NoContent();
        }
    }
}