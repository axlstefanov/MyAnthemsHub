using MediatR;
using MyAnthemsAPI.Data;
using MyAnthemsAPI.Models.UserManagement;

namespace MyAnthemsAPI.Management.UserManagement.Commands
{
    public class CreateUserCommandHandler (AppDbContext context) : IRequestHandler<CreateUserCommand, Guid>
    {
        public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Username = command.Username,
                Password = command.Password,
                Email = command.Email,
            };

            await context.Users.AddAsync(newUser, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return newUser.Id;
        }
    }
}