using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;
using MyAnthemsAPI.Management.UserManagement.Dtos;

namespace MyAnthemsAPI.Management.UserManagement.Queries
{
    public class ListUsersQueryHandler (AppDbContext context, IMapper mapper) : IRequestHandler<ListUsersQuery, List<UserDto>>
    {
        public async Task<List<UserDto>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await context.Users.ToListAsync();
            List<UserDto> resultingDtoList = mapper.Map<List<UserDto>>(result);

            return resultingDtoList;
        }
    }
}