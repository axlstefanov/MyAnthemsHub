using MediatR;
using MyAnthemsAPI.Management.LoginManagement.Dtos;

namespace MyAnthemsAPI.Management.LoginManagement.Commands
{
    public record LoginCommand(string Email, string Password) : IRequest<LoginResponseDto>;
}