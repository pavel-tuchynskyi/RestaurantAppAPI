using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Enums;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Ingridients.Command.CreateIngridient;
using RestaurantApp.Application.Ingridients.Queries.GetIngridients;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Web.Contracts.Ingridients;

namespace RestaurantApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class IngridientsController : BaseController<IngridientsController>
    {
        [HttpPost("{type}")]
        public async Task<RequestResponse<Unit>> Create(string type, [FromForm] CreateIngridientRequest request)
        {
            _logger.LogInformation($"Trying create ingridient of type {type}");
            IRequest<Unit> command = Enum.Parse<FoodType>(type) switch
            {
                FoodType.Japanees => new CreateIngridientCommand<JapaneesFoodIngridient>(request.Name, request.Image),
                FoodType.Italian => new CreateIngridientCommand<ItalianFoodIngridient>(request.Name, request.Image),
                _ => throw new BadRequestException("Unknown type of ingridient")
            };

            var result = await Mediator.Send(command);

            _logger.LogInformation($"{type} ingridient {request.Name} successfully created");

            return new RequestResponse<Unit>(201, result);
        }

        [HttpPost("{type}")]
        public async Task<RequestResponse<PagedList<IngridientDto>>> GetAll(string type, [FromQuery]string name)
        {
            _logger.LogInformation($"Requesting ingridients of type {type}");

            IRequest<PagedList<IngridientDto>> query = Enum.Parse<FoodType>(type) switch
            {
                FoodType.Japanees => new GetIngridientsQuery<JapaneesFoodIngridient>(name),
                FoodType.Italian => new GetIngridientsQuery<ItalianFoodIngridient>(name),
                _ => throw new BadRequestException("Unknown type of ingridient")
            };

            var result = await Mediator.Send(query);

            _logger.LogInformation("Request of ingridients of type {Type} completed. Found {@Count} records", type, result.TotalRecords);

            return new RequestResponse<PagedList<IngridientDto>>(200, result);
        }

    }
}
