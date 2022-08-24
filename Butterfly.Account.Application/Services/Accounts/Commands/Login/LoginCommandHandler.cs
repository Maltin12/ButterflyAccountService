using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Butterfly.Account.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Butterfly.Account.Application.Services.Accounts.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        public LoginCommandHandler(UserManager<User> userManager,
            SignInManager<User> signInManager,
            IConfiguration configuration,
            IMediator mediator
            )
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<LoginModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            var response = await _signInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);

            var notification = new LoginEmailNoification
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            if (!response.Succeeded) return null;
            if (user.IsFirstTime == true)
            {
                await _mediator.Publish(notification);
                user.IsFirstTime = false;
                await _userManager.UpdateAsync(user);
            }
            var Claim = await _userManager.GetClaimsAsync(user);

            return GenerateJwt(Claim);
        }

        private LoginModel GenerateJwt(IList<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration["Authentication:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginModel
            {
                Token = tokenHandler.WriteToken(token),
                Expires_in = tokenDescriptor.Expires,
                Schema = JwtBearerDefaults.AuthenticationScheme
            };
        }
    }
}
