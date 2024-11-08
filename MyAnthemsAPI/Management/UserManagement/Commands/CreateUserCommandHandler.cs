using MediatR;
using MyAnthemsAPI.Data;
using MyAnthemsAPI.Models.UserManagement;

namespace MyAnthemsAPI.Management.UserManagement.Commands
{
    public class CreateUserCommandHandler (AppDbContext context) : IRequestHandler<CreateUserCommand, User>
    {
        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            //user already exists...
            var newUser = new User
            {
                Username = command.Username,
                Password = command.Password,
                Email = command.Email,
            };

            context.Users.Add(newUser);
            await context.SaveChangesAsync();
            return newUser;
        }
    }
}
