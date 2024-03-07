using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Account.Commands.ConfirmEmail;
using RestaurantApp.Application.Account.Commands.Register;
using RestaurantApp.Application.Account.Quries.Login;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Web.Contracts.Account;

namespace RestaurantApp.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : BaseController<AccountController>
    {
        [HttpPost]
        public async Task<RequestResponse<Unit>> Register(RegisterCommand command)
        {
            _logger.LogInformation($"Registering new user: {command.Email}");
            var result = await Mediator.Send(command);

            _logger.LogInformation($"User {command.Email} registered successfully");
            return new RequestResponse<Unit>(201, result);
        }

        [HttpPost]
        public async Task<RequestResponse<AccessToken>> Login(LoginQuery query)
        {
            _logger.LogInformation($"Login user {query.Email} to account");
            var result = await Mediator.Send(query);

            _logger.LogInformation($"User {query.Email} successfully logs into account");
            return new RequestResponse<AccessToken>(200, result);
        }

        [HttpGet]
        public async Task<RequestResponse<Unit>> ConfirmEmail([FromQuery]EmailConfirmRequest request)
        {
            var command = new ConfirmEmailCommand(request.id, request.token);

            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(200, result);
        }
    }
}
