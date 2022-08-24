using MediatR;

namespace Butterfly.Account.Application.Services.Accounts.Queries
{
    class ForgotPasswordEmailNotification : INotification
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string URL { get; set; }
    }
}