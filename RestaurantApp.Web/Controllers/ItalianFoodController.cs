using MediatR;
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
    public class ItalianFoodController : BaseController
    {
        [HttpPost("{type}")]
        public async Task<RequestResponse<Unit>> Create(string type, [FromForm] CreateFoodRequest request)
        {
            IRequest<Unit> command = type switch
            {
                nameof(Pizza) => new CreateItalianFoodCommand<Pizza>(request.Name, request.Image, request.Price, request.Components),
                _ => throw new UnreachableException()
            };

            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(201, result);
        }

        [HttpGet("{type}")]
        public async Task<RequestResponse<FoodItemDto>> Get(string type, [FromQuery] Guid id)
        {
            var query = type switch
            {
                nameof(Pizza) => new GetItalianFoodItemQuery<Pizza>(id),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var item = await Mediator.Send(query);

            return new RequestResponse<FoodItemDto>(200, item);
        }

        [HttpPost("{type}")]
        public async Task<RequestResponse<PagedList<FoodItemDto>>> GetAll(string type, [FromBody]GetFoodRequest request)
        {
            var query = type switch
            {
                nameof(Pizza) => new GetItalianFoodQuery<Pizza>(request.Search, request.OrderBy, request.Paging),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var result = await Mediator.Send(query);

            return new RequestResponse<PagedList<FoodItemDto>>(200, result);
        }

        [HttpPut]
        public async Task<RequestResponse<Unit>> Update([FromQuery] Guid id, [FromForm]UpdateFoodRequest request)
        {
            var command = new UpdateItalianFoodCommand(id, request.Name, request.Image, request.Price);

            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(200, result);
        }

        [HttpDelete]
        public async Task<RequestResponse<Unit>> Delete([FromQuery] Guid id)
        {
            var command = new DeleteItalianFoodCommand(id);

            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(200, result);
        }
    }
}
