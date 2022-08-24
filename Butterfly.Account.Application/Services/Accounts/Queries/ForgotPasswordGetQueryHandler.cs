using System.Text;
using Butterfly.Account.Common.Extensions;
using Butterfly.Account.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Butterfly.Account.Application.Services.Accounts.Queries
{
    class ForgotPasswordHandler : IRequestHandler<ForgotPasswordGetQuery, Unit>
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public ForgotPasswordHandler(UserManager<User> userManager, IConfiguration configuration,IMediator mediator)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        }
        public async Task<Unit> Handle(ForgotPasswordGetQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) return Unit.Value;

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            var notification = new ForgotPasswordEmailNotification
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                URL = PrepareUrl(user.Email, token)
            };

            await _mediator.Publish(notification);

            return Unit.Value;
        }

        private string PrepareUrl(string email, string token)
        {
            var url = _configuration["EmailEndPoints:ResetPassword"];

            email = email.Encode(Encoding.UTF8);
            token = token.Encode(Encoding.UTF8);

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
    }
}
