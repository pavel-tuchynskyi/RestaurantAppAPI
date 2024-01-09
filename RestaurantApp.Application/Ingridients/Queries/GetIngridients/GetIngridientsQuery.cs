using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Domain.MenuItems.Entities;

namespace RestaurantApp.Application.Ingridients.Queries.GetIngridients
{
    public record GetIngridientsQuery<T>(string Name) 
        : IRequest<PagedList<IngridientDto>>
        where T : Ingridient;
}
