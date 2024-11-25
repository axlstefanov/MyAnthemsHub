﻿using MediatR;

namespace MyAnthemsAPI.Management.UserManagement.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}