using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.DrinkMenu.Commands.CreateDrinkItem;
using RestaurantApp.Application.DrinkMenu.Commands.UpdateDrinkItem;
using RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItem;
using RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItems;
using RestaurantApp.Application.ItalianFoodMenu.Commands.DeleteItalianFood;
using RestaurantApp.Domain.MenuItems.Drink;
using RestaurantApp.Web.Contracts.Menu;

namespace RestaurantApp.Web.Controllers
{
    [Authorize]
    [Route("api/Menu/Drink/[action]")]
    public class DrinkController : BaseController<DrinkController>
    {
        [HttpPost("{type}")]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Create(string type, [FromForm] CreateDrinkRequest request)
        {
            _logger.LogInformation($"Trying create drink item of type {type}");

            IRequest<Unit> command = type switch
            {
                nameof(Wine) => new CreateDrinkItemCommand<Wine>(request.Name, request.Image, request.Price, request.Description),
                nameof(Beer) => new CreateDrinkItemCommand<Beer>(request.Name, request.Image, request.Price, request.Description),
                nameof(NonAlcohol) => new CreateDrinkItemCommand<NonAlcohol>(request.Name, request.Image, request.Price, request.Description),
                _ => throw new BadRequestException("Unknown type of drink")
            };

            var result = await Mediator.Send(command);

            _logger.LogInformation($"{type} drink item {request.Name} successfully created");

            return new RequestResponse<Unit>(201, result);
        }

        [HttpGet("{type}")]
        public async Task<RequestResponse<DrinkItemDto>> Get(string type, [FromQuery]Guid id)
        {
            _logger.LogInformation($"Requesting drink item with id {id}");

            IRequest<DrinkItemDto> query = type switch
            {
                nameof(Wine) => new GetDrinkItemQuery<Wine>(id),
                nameof(Beer) => new GetDrinkItemQuery<Beer>(id),
                nameof(NonAlcohol) => new GetDrinkItemQuery<NonAlcohol>(id),
                _ => throw new BadRequestException("Unknown type of drink")
            };

            var result = await Mediator.Send(query);

            _logger.LogInformation("Request of drink item with id {Id} completed. \n{@Item}", id, result);

            return new RequestResponse<DrinkItemDto>(200, result);
        }

        [HttpPost("{type}")]
        public async Task<RequestResponse<PagedList<DrinkItemDto>>> GetAll(string type, [FromBody] GetFoodRequest request)
        {
            _logger.LogInformation($"Requesting drink items of type {type}");

            IRequest<PagedList<DrinkItemDto>> query = type switch
            {
                nameof(Wine) => new GetDrinkItemsQuery<Wine>(request.Search, request.OrderBy, request.Paging),
                nameof(Beer) => new GetDrinkItemsQuery<Beer>(request.Search, request.OrderBy, request.Paging),
                nameof(NonAlcohol) => new GetDrinkItemsQuery<NonAlcohol>(request.Search, request.OrderBy, request.Paging),
                _ => throw new BadRequestException("Unknown type of drink")
            };

            var result = await Mediator.Send(query);

            _logger.LogInformation("Request of drink items of type {Type} completed. Found {@Count} records", type, result.TotalRecords);

            return new RequestResponse<PagedList<DrinkItemDto>>(200, result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Update([FromQuery]Guid id, [FromForm] UpdateDrinkRequest request)
        {
            _logger.LogInformation($"Trying to update drink item with id {id}");

            var query = new UpdateDrinkItemCommand(id, request.Name, request.Image, request.Price, request.Description);

            var result = await Mediator.Send(query);

            _logger.LogInformation($"Drink item with id {id} updated successfully");

            return new RequestResponse<Unit>(200, result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Delete([FromQuery] Guid id)
        {
            _logger.LogInformation($"Trying to delete drink item with id {id}");

            var query = new DeleteItalianFoodCommand(id);

            var result = await Mediator.Send(query);

            _logger.LogInformation($"Drink item with id {id} was deleted successfully");

            return new RequestResponse<Unit>(200, result);
        }
    }
}
