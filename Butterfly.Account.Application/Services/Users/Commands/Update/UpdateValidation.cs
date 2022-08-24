using FluentValidation;

namespace Butterfly.Account.Application.Services.Users.Commands.Update
{
    public class UpdateValidation : AbstractValidator<UpdateCommand>
    {
        public UpdateValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email must not be null");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name must not be null");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name must not be null");
        }
    }
}