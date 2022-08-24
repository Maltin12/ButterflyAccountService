using AutoMapper;
using Butterfly.Account.Application.Interfaces;
using Butterfly.Account.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Butterfly.Account.Application.Services.Users.Queries.GetCitiesByCountry
{
    public class GetCitiesByCountryQueryHandler : IRequestHandler<GetCitiesByCountryQuery, IList<GetCitiesByCountryModel>>
    {
        private readonly IAccountDbContext _context;

        private readonly IMapper _mapper;

        public GetCitiesByCountryQueryHandler(IAccountDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IList<GetCitiesByCountryModel>> Handle(GetCitiesByCountryQuery request, CancellationToken cancellationToken)
        {
            var cities = await _context.Cities.Where(x => x.CountryId == request.CountryId).ToListAsync();

            return _mapper.Map<IList<City> ,IList<GetCitiesByCountryModel>>(cities);
        }
    }
}