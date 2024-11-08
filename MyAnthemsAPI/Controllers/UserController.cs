using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAnthemsAPI.Management.UserManagement.Commands;

namespace MyAnthemsAPI.Controllers
{
    public class UserController(ISender mediatr) : ControllerBase
    {
        [HttpPost]
        public async Task<IResult> Add([FromBody] CreateUserCommand command)
        {
            var user = await mediatr.Send(command);
            if (user == null)
            {
                return Results.BadRequest();
            }

            return Results.Created($"/Right/{user}", new { user });
        }
    }
}