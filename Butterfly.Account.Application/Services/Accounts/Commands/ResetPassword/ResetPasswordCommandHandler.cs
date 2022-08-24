using System.Text;
using Butterfly.Account.Common.Extensions;
using Butterfly.Account.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Butterfly.Account.Application.Services.Accounts.Commands.ResetPassword
{
    class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand>
    {
        private readonly UserManager<User> _userManager;

        public ResetPasswordCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<Unit> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email.Decode(Encoding.UTF8);

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return Unit.Value;

            var token = request.Token.Decode(Encoding.UTF8);

            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);

            if (!result.Succeeded) return Unit.Value;

            return Unit.Value;
        }
    }
}