using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAnthemsAPI.Management.LoginManagement.Commands;

namespace MyAnthemsAPI.Controllers
{
    public class LoginController(ISender mediatr) : GenericController
    {
        [HttpPost]
        public async Task<IResult> Login(LoginCommand command)
        {
            var response = await mediatr.Send(command);
            if (Guid.Empty == response.Id || string.IsNullOrEmpty(response.Token))
            {
                return Results.Forbid();
            }

            return Results.Ok(response);
        }
    }
}