using Butterfly.Account.Application.Services.Users.Commands.Add;
using FluentValidation;
using Butterfly.Account.Common.Constants;

namespace visionagency.Butterfly.Account.Application.Services.Users.Commands.Add
{
    public class AddCommandValidation : AbstractValidator<AddCommand>
    {
        public AddCommandValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required!");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Last name length must be at least 3 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.Email).Matches(Regex.Email).WithMessage("Please provide a valid email address");
        }
    }
}