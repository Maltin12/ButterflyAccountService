using FluentValidation;

namespace Butterfly.Account.Application.Services.Users.Commands.ChangePassword
{
    public class ChangePasswordCommandValidation : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidation()
        {
            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage("Current password is required!");
            RuleFor(x => x.CurrentPassword).MinimumLength(8).WithMessage("The password must contain eight characters and should contain at least one symbol,uppercase and lowercase letter and at least one number!");
            RuleFor(x => x.NewPasword).NotEmpty().WithMessage("New Password is required!");
            RuleFor(x => x.NewPasword).MinimumLength(8).WithMessage("The password must contain eight characters and should contain at least one symbol,uppercase and lowercase letter and at least one number!");       
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
        }
    }
}