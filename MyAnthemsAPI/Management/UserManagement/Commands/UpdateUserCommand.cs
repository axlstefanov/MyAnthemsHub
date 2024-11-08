using MediatR;

namespace MyAnthemsAPI.Management.UserManagement.Commands
{
    public class UpdateUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}