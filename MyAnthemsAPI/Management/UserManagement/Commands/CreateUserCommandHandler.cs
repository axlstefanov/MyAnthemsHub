using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;
using MyAnthemsAPI.Models.UserManagement;

namespace MyAnthemsAPI.Management.UserManagement.Commands
{
    public class CreateUserCommandHandler(AppDbContext context) : IRequestHandler<CreateUserCommand, Guid>
    {
        public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(command.Password);
            var newUser = new User
            {
                Username = command.Username,
                Password = hashedPassword,
                Email = command.Email,
            };

            var foundUser = await context.Users.FirstOrDefaultAsync(x => x.Username == newUser.Username, cancellationToken);
            if (foundUser != null)
            {
                throw new Exception("Username already in use.");
            }
            foundUser = await context.Users.FirstOrDefaultAsync(x => x.Email == newUser.Email, cancellationToken);
            if (foundUser != null)
            {
                throw new Exception("Email already in use.");
            }

            await context.Users.AddAsync(newUser, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return newUser.Id;
        }
    }
}