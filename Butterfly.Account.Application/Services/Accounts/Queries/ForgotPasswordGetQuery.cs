using MediatR;

namespace Butterfly.Account.Application.Services.Accounts.Queries
{
    public class ForgotPasswordGetQuery : IRequest<Unit>
    { 
        public string Email { get; set; }
    }
}