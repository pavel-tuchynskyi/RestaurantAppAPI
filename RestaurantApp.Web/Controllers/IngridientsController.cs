using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Common.Enums;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Ingridients.Command.CreateIngridient;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Web.Contracts.Ingridients;

namespace RestaurantApp.Web.Controllers
{
    public class IngridientsController : BaseController
    {
        [HttpPost("{type}")]
        public async Task<RequestResponse<Unit>> Create(string type, [FromForm] CreateIngridient form)
        {
            IRequest<Unit> request = Enum.Parse<FoodType>(type) switch
            {
                FoodType.Japanees => new CreateIngridientCommand<JapaneesFoodIngridient>(form.Name, form.Image),
                FoodType.Italian => new CreateIngridientCommand<ItalianFoodIngridient>(form.Name, form.Image),
                _ => throw new BadRequestException("Unknown type of ingridient")
            };

            var result = await Mediator.Send(request);

            return new RequestResponse<Unit>(201, result);
        }
    }
}
