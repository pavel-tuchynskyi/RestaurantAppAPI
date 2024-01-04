using MediatR;

namespace RestaurantApp.Application.Account.Quries.Login
{
    public class LoginQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
