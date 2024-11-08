using MediatR;
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
            var user = await mediatr.Send(command);
            if (user == null)
            {
                return Results.BadRequest();
            }

            return Results.Created($"/Right/{user}", new { user });
        }

        [HttpGet]
        public async Task<IResult> GetAll()
        {
            var users = await mediatr.Send(new ListUsersQuery());
            return Results.Ok(users);
        }
    }
}