using MediatR;

namespace Butterfly.Account.Application.Services.Users.Queries.Get
{
    public class GetUserQuery : IRequest<IList<GetUserModel>>
    {
    }
}