using System.Security.Claims;
using System.Text;
using AutoMapper;
using Butterfly.Account.Common.Extensions;
using Butterfly.Account.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Butterfly.Account.Application.Services.Users.Commands.Add
{
    public class AddCommandHandler : IRequestHandler<AddCommand, AddModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public AddCommandHandler(UserManager<User> userManager,
            IMapper mapper,
            IMediator mediator,
            IConfiguration configuration)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public async Task<AddModel> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AddCommand, User>(request);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                user = await _userManager.FindByEmailAsync(request.Email);
                CreateUserClaims(user);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var notification = new AddEmailNotification
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    URL = PrepareUrl(request.Email, token)
                };

                await _mediator.Publish(notification);

                return _mapper.Map<User, AddModel>(user);
            }

            return null;
        }

        private string PrepareUrl(string email, string token)
        {
            var url = _configuration["EmailEndPoints:Confirmation"];

            token = token.Encode(Encoding.UTF8);

            email = email.Encode(Encoding.UTF8);

            IDictionary<string, string> placeholders = new Dictionary<string, string>()
            {
                { "<#EMAIL#>",email},
                { "<#TOKEN#>",token}
            };

            foreach (var placeholder in placeholders)
            {
                url = url.Replace(placeholder.Key, placeholder.Value);
            }

            return url;
        }
        private async void CreateUserClaims(User user)
        {
            var claims = new List<Claim>
            {
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                    new Claim(ClaimTypes.Email, user.Email)
            };

            await _userManager.AddClaimsAsync(user, claims);
        }
    }


}