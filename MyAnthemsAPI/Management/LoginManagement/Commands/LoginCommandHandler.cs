﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;
using MyAnthemsAPI.Management.LoginManagement.Dtos;
using MyAnthemsAPI.Services.Authentication;

namespace MyAnthemsAPI.Management.LoginManagement.Commands
{
    public class LoginCommandHandler(AppDbContext context, IJwtTokenService tokenService) : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        public async Task<LoginResponseDto> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var foundUser = await context.Users.SingleOrDefaultAsync(x => x.Email == command.Email, cancellationToken);
            if (foundUser == null || !BCrypt.Net.BCrypt.Verify(command.Password, foundUser.Password))
            {
                return new LoginResponseDto(Guid.Empty, "", "", "");
            }

            var token = tokenService.GenerateToken(foundUser);
            return new LoginResponseDto(foundUser.Id, foundUser.Username, foundUser.Email, token);
        }
    }
}