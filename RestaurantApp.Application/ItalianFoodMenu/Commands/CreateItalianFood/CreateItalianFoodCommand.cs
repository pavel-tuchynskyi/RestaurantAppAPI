using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.CreateItalianFood
{
    public record CreateItalianFoodCommand<T>(
        string Name,
        IFormFile Image,
        decimal Price,
        List<Guid> Components) : IRequest<Unit>
        where T : ItalianFood;
}
