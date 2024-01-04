using MediatR;
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
using System.Diagnostics;

namespace RestaurantApp.Web.Controllers
{
    public class JapaneesFoodController : BaseController
    {
        [HttpPost("{type}")]
        public async Task<RequestResponse<Unit>> Create(string type, [FromForm]CreateFoodRequest request)
        {
            IRequest<Unit> command = type switch
            {
                nameof(Susi) => new CreateJapaneesFoodCommand<Susi>(request.Name, request.Image, request.Price, request.Components),
                nameof(Rolls) => new CreateJapaneesFoodCommand<Rolls>(request.Name, request.Image, request.Price, request.Components),
                nameof(Set) => new CreateJapaneesFoodCommand<Set>(request.Name, request.Image, request.Price, request.Components),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(201, result);
        }

        [HttpPut]
        public async Task<RequestResponse<Unit>> Update([FromQuery] Guid id, [FromForm] UpdateFoodRequest request)
        {
            var command = new UpdateJapaneesFoodCommand(id, request.Name, request.Image, request.Price);

            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(200, result);
        }

        [HttpDelete]
        public async Task<RequestResponse<Unit>> Delete([FromQuery] Guid id)
        {
            var command = new DeleteJapaneesFoodCommand(id);

            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(200, result);
        }

        [HttpGet("{type}")]
        public async Task<RequestResponse<FoodItemDto>> Get(string type, [FromQuery] Guid id)
        {
            IRequest<FoodItemDto> query = type switch
            {
                nameof(Susi) => new GetJapaneesFoodItemQuery<Susi>(id),
                nameof(Rolls) => new GetJapaneesFoodItemQuery<Rolls>(id),
                nameof(Set) => new GetJapaneesFoodItemQuery<Set>(id),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var item = await Mediator.Send(query);

            return new RequestResponse<FoodItemDto>(200, item);
        }

        [HttpPost("{type}")]
        public async Task<RequestResponse<PagedList<FoodItemDto>>> GetAll(string type, [FromBody] GetFoodRequest request)
        {
            IRequest<PagedList<FoodItemDto>> query = type switch
            {
                nameof(Susi) => new GetJapaneesFoodQuery<Susi>(request.Search, request.OrderBy, request.Paging),
                nameof(Rolls) => new GetJapaneesFoodQuery<Rolls>(request.Search, request.OrderBy, request.Paging),
                nameof(Set) => new GetJapaneesFoodQuery<Set>(request.Search, request.OrderBy, request.Paging),
                _ => throw new BadRequestException("Unknown type of food")
            };

            var result = await Mediator.Send(query);

            return new RequestResponse<PagedList<FoodItemDto>>(200, result);
        }
    }
}
