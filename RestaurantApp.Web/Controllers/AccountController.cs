using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Account.Commands.Register;
using RestaurantApp.Application.Account.Quries.Login;

namespace RestaurantApp.Web.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
