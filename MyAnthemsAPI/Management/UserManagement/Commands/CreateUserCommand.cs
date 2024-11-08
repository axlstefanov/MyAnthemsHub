using MediatR;
using MyAnthemsAPI.Models.UserManagement;

namespace MyAnthemsAPI.Management.UserManagement.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}