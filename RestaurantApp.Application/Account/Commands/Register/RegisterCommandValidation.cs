using FluentValidation;

namespace RestaurantApp.Application.Account.Commands.Register
{
    public class RegisterCommandValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        }
    }
}
