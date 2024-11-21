using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAnthemsAPI.Management.UserManagement.Commands;
using MyAnthemsAPI.Management.UserManagement.Queries;

namespace MyAnthemsAPI.Controllers
{
    public class UserController(ISender mediatr) : GenericController
    {
        [HttpPost("Add")]
        public async Task<IResult> Add([FromBody] CreateUserCommand command)
        {
            var id = await mediatr.Send(command);
            if (Guid.Empty == id)
            {
                return Results.BadRequest();
            }

            return Results.Created($"/User/{id}", new { id });
        }

        [Authorize]
        [HttpGet("{id:guid}")]
        public async Task<IResult> Get(Guid id)
        {
            var user = await mediatr.Send(new GetUserQuery(id));
            return Results.Ok(user);
        }

        [Authorize]
        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var users = await mediatr.Send(new ListUsersQuery());
            return Results.Ok(users);
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IResult> Update(Guid id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return Results.BadRequest();
            }
            await mediatr.Send(command);
            return Results.NoContent();
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IResult> Delete(Guid id)
        {
            await mediatr.Send(new DeleteUserCommand(id));
            return Results.NoContent();
        }
    }
}