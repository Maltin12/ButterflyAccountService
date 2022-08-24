using MediatR;

namespace Butterfly.Account.Application.Services.Users.Queries.GetCitiesByCountry
{
    public class GetCitiesByCountryQuery : IRequest<IList<GetCitiesByCountryModel>>
    {
        public Guid CountryId { get; set; }
    }
}