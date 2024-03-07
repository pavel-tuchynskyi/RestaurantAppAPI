using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.ItalianFoodMenu.Commands.CreateItalianFood;
using RestaurantApp.Application.ItalianFoodMenu.Commands.DeleteItalianFood;
using RestaurantApp.Application.ItalianFoodMenu.Commands.UpdateItalianFood;
using RestaurantApp.Application.ItalianFoodMenu.Queries.GetFoodItem;
using RestaurantApp.Application.ItalianFoodMenu.Queries.GetItalianFood;
using RestaurantApp.Domain.MenuItems.Food.Italian;
using RestaurantApp.Web.Contracts.Menu;
using System.Diagnostics;

namespace RestaurantApp.Web.Controllers
{
    [Authorize]
    [Route("api/Menu/Italian/[action]")]
    public class ItalianFoodController : BaseController<ItalianFoodController>
    {
        [HttpPost("{type}")]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Create(string type, [FromForm] CreateFoodRequest request)
        {
            _logger.LogInformation($"Trying create italian food item of type {type}");

            IRequest<Unit> command = type switch
            {
                nameof(Pizza) => new CreateItalianFoodCommand<Pizza>(request.Name, request.Image, request.Price, request.Components),
                _ => throw new UnreachableException()
            };

            var result = await Mediator.Send(command);

            _logger.LogInformation($"{type} italian food item {request.Name} successfully created");

            return new RequestResponse<Unit>(201, result);
        }

        [HttpGet("{type}")]
        public async Task<RequestResponse<FoodItemDto>> Get(string type, [FromQuery] Guid id)
        {
            _logger.LogInformation($"Requesting italian food item with id {id}");

            IRequest<FoodItemDto> query = type switch
            {
                nameof(Pizza) => new GetItalianFoodItemQuery<Pizza>(id),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var result = await Mediator.Send(query);

            _logger.LogInformation("Request of italian food item with id {Id} completed. \n{@Item}", id, result);

            return new RequestResponse<FoodItemDto>(200, result);
        }

        [HttpPost("{type}")]
        public async Task<RequestResponse<PagedList<FoodItemDto>>> GetAll(string type, [FromBody]GetFoodRequest request)
        {
            _logger.LogInformation($"Requesting italian food items of type {type}");

            IRequest<PagedList<FoodItemDto>> query = type switch
            {
                nameof(Pizza) => new GetItalianFoodQuery<Pizza>(request.Search, request.OrderBy, request.Paging),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var result = await Mediator.Send(query);

            _logger.LogInformation("Request of italian food items of type {Type} completed. Found {@Count} records", type, result.TotalRecords);

            return new RequestResponse<PagedList<FoodItemDto>>(200, result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Update([FromQuery] Guid id, [FromForm]UpdateFoodRequest request)
        {
            _logger.LogInformation($"Trying to update italian food item with id {id}");

            var command = new UpdateItalianFoodCommand(id, request.Name, request.Image, request.Price);

            var result = await Mediator.Send(command);

            _logger.LogInformation($"Italian food item with id {id} updated successfully");

            return new RequestResponse<Unit>(200, result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Delete([FromQuery] Guid id)
        {
            _logger.LogInformation($"Trying to delete italian food item with id {id}");

            var command = new DeleteItalianFoodCommand(id);

            var result = await Mediator.Send(command);

            _logger.LogInformation($"Italian food item with id {id} was deleted successfully");

            return new RequestResponse<Unit>(200, result);
        }
    }
}
