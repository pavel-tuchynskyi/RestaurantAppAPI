using MediatR;
using Microsoft.AspNetCore.Http;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.UpdateJapaneesFood
{
    public record UpdateJapaneesFoodCommand(
        Guid Id,
        string Name, 
        IFormFile Image,
        decimal Price) 
        : IRequest<Unit>;
}
