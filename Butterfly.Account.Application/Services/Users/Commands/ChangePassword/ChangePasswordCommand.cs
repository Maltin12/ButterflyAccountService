using MediatR;

namespace Butterfly.Account.Application.Services.Users.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Unit>
    {
        public string CurrentPassword { get; set; }
        public string NewPasword { get; set; }
        public string Email { get; set; }
    }
}