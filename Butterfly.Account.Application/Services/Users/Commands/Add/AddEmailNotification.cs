using MediatR;

namespace Butterfly.Account.Application.Services.Users.Commands.Add
{
    public class AddEmailNotification : INotification
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string URL { get; set; }
    }
}