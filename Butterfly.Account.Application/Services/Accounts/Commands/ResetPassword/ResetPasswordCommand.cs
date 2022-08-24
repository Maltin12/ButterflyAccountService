using MediatR;

namespace Butterfly.Account.Application.Services.Accounts.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest<Unit>
    {
        public string  Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}