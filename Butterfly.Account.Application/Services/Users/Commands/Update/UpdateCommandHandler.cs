using Butterfly.Account.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Butterfly.Account.Application.Services.Users.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Unit>
    {
        private readonly IAccountDbContext _context;
        public UpdateCommandHandler(IAccountDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == request.Email);

            if (user == null) return Unit.Value;

            user.FirstName = request.FirstName;

            user.LastName = request.LastName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}