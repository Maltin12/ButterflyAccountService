using System.Text;
using AutoMapper;
using Butterfly.Account.Common.Extensions;
using Butterfly.Account.Domain.Entities;
using MediatR;
using Butterfly.Account.Common.Extensions;
using Microsoft.AspNetCore.Identity;

namespace Butterfly.Account.Application.Services.Accounts.Commands.ConfirmEmail
{
    public class ConfirmEmailHandler : IRequestHandler<ConfirmEmailCommand, ConfirmEmailModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        
        public ConfirmEmailHandler(
            UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<ConfirmEmailModel> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email.Decode(Encoding.UTF8));

            if (user == null) throw new ArgumentNullException(user.Email);

            var result = await _userManager.ConfirmEmailAsync(user, request.Token.Decode(Encoding.UTF8));

            if (!result.Succeeded) return null;

            var confirm = _mapper.Map<ConfirmEmailCommand, User>(request);

            if (confirm == null) return null;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            token = token.Encode(Encoding.UTF8);
            
            return new ConfirmEmailModel
            {
                Email = request.Email,
                Token = token
            };
        }
    }
}