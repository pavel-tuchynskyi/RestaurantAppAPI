using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.CreateJapaneesFood
{
    public record CreateJapaneesFoodCommand<T>(
        string Name,
        IFormFile Image,
        decimal Price,
        List<Guid> Components) : IRequest<Unit>
        where T : JapaneesFood;
}
