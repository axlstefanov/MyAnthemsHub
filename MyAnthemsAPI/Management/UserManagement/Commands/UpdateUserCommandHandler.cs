using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;

namespace MyAnthemsAPI.Management.UserManagement.Commands
{
    public class UpdateUserCommandHandler(AppDbContext context) : IRequestHandler<UpdateUserCommand>
    {
        public async Task Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var foundUser = await context.Users.SingleAsync(x => x.Id == command.Id, cancellationToken);
            foundUser.Username = command.Username;
            foundUser.Email = command.Email;
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}