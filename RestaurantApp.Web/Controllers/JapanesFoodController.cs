using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.JapaneesFoodMenu.Commands.CreateJapaneesFood;
using RestaurantApp.Application.JapaneesFoodMenu.Commands.DeleteJapaneesFood;
using RestaurantApp.Application.JapaneesFoodMenu.Commands.UpdateJapaneesFood;
using RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFood;
using RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFoodItem;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Web.Contracts.Menu;

namespace RestaurantApp.Web.Controllers
{
    [Authorize]
    [Route("api/Menu/Japanes/[action]")]
    public class JapanesFoodController : BaseController<JapanesFoodController>
    {
        [HttpPost("{type}")]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Create(string type, [FromForm]CreateFoodRequest request)
        {
            _logger.LogInformation($"Trying create japanees food item of type {type}");

            IRequest<Unit> command = type switch
            {
                nameof(Susi) => new CreateJapaneesFoodCommand<Susi>(request.Name, request.Image, request.Price, request.Components),
                nameof(Rolls) => new CreateJapaneesFoodCommand<Rolls>(request.Name, request.Image, request.Price, request.Components),
                nameof(Set) => new CreateJapaneesFoodCommand<Set>(request.Name, request.Image, request.Price, request.Components),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var result = await Mediator.Send(command);

            _logger.LogInformation($"{type} japanees food item {request.Name} successfully created");

            return new RequestResponse<Unit>(201, result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Update([FromQuery] Guid id, [FromForm] UpdateFoodRequest request)
        {
            _logger.LogInformation($"Trying to update japanees food item with id {id}");

            var command = new UpdateJapaneesFoodCommand(id, request.Name, request.Image, request.Price);

            var result = await Mediator.Send(command);

            _logger.LogInformation($"Japanees food item with id {id} updated successfully");

            return new RequestResponse<Unit>(200, result);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Delete([FromQuery] Guid id)
        {
            _logger.LogInformation($"Trying to delete japanees food item with id {id}");

            var command = new DeleteJapaneesFoodCommand(id);

            var result = await Mediator.Send(command);

            _logger.LogInformation($"Japanees food item with id {id} was deleted successfully");

            return new RequestResponse<Unit>(200, result);
        }

        [HttpGet("{type}")]
        public async Task<RequestResponse<FoodItemDto>> Get(string type, [FromQuery] Guid id)
        {
            _logger.LogInformation($"Requesting japanees food item with id {id}");

            IRequest<FoodItemDto> query = type switch
            {
                nameof(Susi) => new GetJapaneesFoodItemQuery<Susi>(id),
                nameof(Rolls) => new GetJapaneesFoodItemQuery<Rolls>(id),
                nameof(Set) => new GetJapaneesFoodItemQuery<Set>(id),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var result = await Mediator.Send(query);

            _logger.LogInformation("Request of japanees food item with id {Id} completed. \n{@Item}", id, result);

            return new RequestResponse<FoodItemDto>(200, result);
        }

        [HttpPost("{type}")]
        public async Task<RequestResponse<PagedList<FoodItemDto>>> GetAll(string type, [FromBody] GetFoodRequest request)
        {
            _logger.LogInformation($"Requesting japanees food items of type {type}");

            IRequest<PagedList<FoodItemDto>> query = type switch
            {
                nameof(Susi) => new GetJapaneesFoodQuery<Susi>(request.Search, request.OrderBy, request.Paging),
                nameof(Rolls) => new GetJapaneesFoodQuery<Rolls>(request.Search, request.OrderBy, request.Paging),
                nameof(Set) => new GetJapaneesFoodQuery<Set>(request.Search, request.OrderBy, request.Paging),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var result = await Mediator.Send(query);

            _logger.LogInformation("Request of japanees food items of type {Type} completed. Found {@Count} records", type, result.TotalRecords);

            return new RequestResponse<PagedList<FoodItemDto>>(200, result);
        }
    }
}
