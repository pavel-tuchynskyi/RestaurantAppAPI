using FluentValidation;

namespace RestaurantApp.Application.Account.Quries.Login
{
    public class LoginQueryValidation : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidation()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
        }
    }
}
