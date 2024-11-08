using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;
using MyAnthemsAPI.Management.UserManagement.Dtos;

namespace MyAnthemsAPI.Management.UserManagement.Queries
{
    public class GetUserQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetUserQuery, UserDto>
    {
        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellation)
        {
            var result = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellation);
            UserDto user = mapper.Map<UserDto>(result);
            return user;
        }
    }
}