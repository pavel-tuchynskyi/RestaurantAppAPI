using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.DrinkMenu.Commands.CreateDrinkItem;
using RestaurantApp.Application.DrinkMenu.Commands.UpdateDrinkItem;
using RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItem;
using RestaurantApp.Application.ItalianFoodMenu.Commands.DeleteItalianFood;
using RestaurantApp.Domain.MenuItems.Drink;
using RestaurantApp.Web.Contracts.Menu;

namespace RestaurantApp.Web.Controllers
{
    public class DrinkController : BaseController
    {
        [HttpPost("{type}")]
        public async Task<RequestResponse<Unit>> Create(string type, [FromForm] CreateDrinkRequest request)
        {
            IRequest<Unit> command = type switch
            {
                nameof(Wine) => new CreateDrinkItemCommand<Wine>(request.Name, request.Image, request.Price, request.Description),
                nameof(Beer) => new CreateDrinkItemCommand<Beer>(request.Name, request.Image, request.Price, request.Description),
                nameof(NonAlcoholDrink) => new CreateDrinkItemCommand<NonAlcoholDrink>(request.Name, request.Image, request.Price, request.Description),
                _ => throw new BadRequestException("Unknown type of drink")
            };

            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(201, result);
        }

        [HttpGet]
        public async Task<RequestResponse<DrinkItemDto>> Get([FromQuery]Guid id)
        {
            var query = new GetDrinkItemQuery(id);

            var result = await Mediator.Send(query);

            return new RequestResponse<DrinkItemDto>(200, result);
        }

        [HttpPut]
        public async Task<RequestResponse<Unit>> Update([FromQuery]Guid id, [FromForm] UpdateDrinkRequest request)
        {
            var query = new UpdateDrinkItemCommand(id, request.Name, request.Image, request.Price, request.Description);

            var result = await Mediator.Send(query);

            return new RequestResponse<Unit>(200, result);
        }

        [HttpDelete]
        public async Task<RequestResponse<Unit>> Delete([FromQuery] Guid id)
        {
            var query = new DeleteItalianFoodCommand(id);

            var result = await Mediator.Send(query);

            return new RequestResponse<Unit>(200, result);
        }
    }
}
