using MediatR;

namespace Butterfly.Account.Application.Services.Users.Queries.GetCountries
{
    public class GetCountriesQuery : IRequest<IList<GetCountriesModel>>
    {

    }
}