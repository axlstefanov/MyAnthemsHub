using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAnthemsAPI.Data;

namespace MyAnthemsAPI.Management.UserManagement.Commands
{
    public class DeleteUserCommandHandler(AppDbContext context) : IRequestHandler<DeleteUserCommand>
    {
        public async Task Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var foundUser = await context.Users.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);
            context.Users.Remove(foundUser);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
