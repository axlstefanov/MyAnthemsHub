using MediatR;

namespace MyAnthemsAPI.Management.UserManagement.Commands
{
    public record DeleteUserCommand(Guid Id) : IRequest;
}
