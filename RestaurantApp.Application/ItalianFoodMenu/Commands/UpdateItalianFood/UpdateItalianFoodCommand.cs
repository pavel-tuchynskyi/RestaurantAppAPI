using MediatR;
using Microsoft.AspNetCore.Http;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.UpdateItalianFood
{
    public record UpdateItalianFoodCommand(
        Guid Id,
        string Name, 
        IFormFile Image,
        decimal Price) 
        : IRequest<Unit>;
}
