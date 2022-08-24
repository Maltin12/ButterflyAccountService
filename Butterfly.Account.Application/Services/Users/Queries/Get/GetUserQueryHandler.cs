using AutoMapper;
using Butterfly.Account.Application.Interfaces;
using Butterfly.Account.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Butterfly.Account.Application.Services.Users.Queries.Get
{
    public class GetQueryHandler : IRequestHandler<GetUserQuery, IList<GetUserModel>>
    {
        private readonly IAccountDbContext _context;
        private readonly IMapper _mapper;
        public GetQueryHandler(IAccountDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IList<GetUserModel>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.ToListAsync();

            return _mapper.Map<IList<User>, IList<GetUserModel>>(users);
        }
    }
}