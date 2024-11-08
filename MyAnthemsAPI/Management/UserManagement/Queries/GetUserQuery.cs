using MediatR;
using MyAnthemsAPI.Management.UserManagement.Dtos;

namespace MyAnthemsAPI.Management.UserManagement.Queries
{
    public record GetUserQuery(Guid Id) : IRequest<UserDto>;
}