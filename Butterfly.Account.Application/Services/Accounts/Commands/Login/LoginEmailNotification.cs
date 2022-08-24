using MediatR;

namespace Butterfly.Account.Application.Services.Accounts.Commands.Login
{
    public class LoginEmailNoification : INotification
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}