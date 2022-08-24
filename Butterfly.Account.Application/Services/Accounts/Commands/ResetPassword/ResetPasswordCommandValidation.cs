using FluentValidation;

namespace Butterfly.Account.Application.Services.Accounts.Commands.ResetPassword
{
    public class ResetPasswordCommandValidation : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required!");
            RuleFor(x => x.NewPassword).MinimumLength(8).WithMessage("New Password must be at last 8 characters");
            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("New Password is required");
            RuleFor(x => x.Token).NotEmpty().WithMessage("Token is required!");
        }
    }
}