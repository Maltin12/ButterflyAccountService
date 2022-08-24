using Butterfly.Account.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Butterfly.Account.Application.Services.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Unit>
    {
        private readonly UserManager<User> _userManager;
        public ChangePasswordCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) return Unit.Value;

            var response =  await _userManager.ChangePasswordAsync(user,request.CurrentPassword,request.NewPasword);

            if (!response.Succeeded) return Unit.Value;

            return Unit.Value;
        }
    }
}