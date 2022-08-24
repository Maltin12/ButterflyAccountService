using FluentValidation;

namespace Butterfly.Account.Application.Services.Users.Queries.GetCitiesByCountry
{
    public class GetCitiesByCountryValidation : AbstractValidator<GetCitiesByCountryQuery>
    {
        public GetCitiesByCountryValidation()
        {
            RuleFor(x => x.CountryId).NotEmpty().WithMessage("Country Id must not be null");
        }

    }
}