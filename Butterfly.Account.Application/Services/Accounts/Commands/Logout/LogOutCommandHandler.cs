using Butterfly.Account.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Butterfly.Account.Application.Services.Accounts.Commands.Logout
{
    public class LogoutCommandHendler : IRequestHandler<LogoutCommand, Unit>
    {
        private readonly SignInManager<User> _signInManager;

        public LogoutCommandHendler(SignInManager<User> signInManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));

        }
        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _signInManager.SignOutAsync();

            return Unit.Value;
        }
    }
}