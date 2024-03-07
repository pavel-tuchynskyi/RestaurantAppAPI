using MediatR;
using RestaurantApp.Application.Common.Models;

namespace RestaurantApp.Application.Account.Quries.Login
{
    public class LoginQuery : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
