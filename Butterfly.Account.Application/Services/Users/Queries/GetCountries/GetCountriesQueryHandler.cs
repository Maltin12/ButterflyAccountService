using AutoMapper;
using Butterfly.Account.Application.Interfaces;
using Butterfly.Account.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Butterfly.Account.Application.Services.Users.Queries.GetCountries
{
    public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IList<GetCountriesModel>>
    {
        private readonly IAccountDbContext _context;
        private readonly IMapper _mapper;

        public GetCountriesQueryHandler(IAccountDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IList<GetCountriesModel>> Handle(GetCountriesQuery request,CancellationToken cancellationToken)
        {
            var countries = await _context.Countries.ToListAsync();

            return _mapper.Map<IList<Country>, IList<GetCountriesModel>>(countries);
        }
    }
}