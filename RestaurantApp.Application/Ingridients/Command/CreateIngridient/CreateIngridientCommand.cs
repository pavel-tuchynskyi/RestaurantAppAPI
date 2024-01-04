using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantApp.Domain.MenuItems.Entities;

namespace RestaurantApp.Application.Ingridients.Command.CreateIngridient
{
    public record CreateIngridientCommand<T> (
        string Name,
        IFormFile Image) : IRequest<Unit>
        where T : Ingridient;
}
