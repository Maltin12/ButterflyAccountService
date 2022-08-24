using MediatR;

namespace Butterfly.Account.Application.Services.Users.Commands.Update
{
    public class UpdateCommand : IRequest<Unit>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}