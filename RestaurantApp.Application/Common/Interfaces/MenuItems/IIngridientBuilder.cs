using RestaurantApp.Application.Common.Enums;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.Common.Interfaces.MenuItems
{
    public interface IIngridientBuilder
    {
        Type Type { get; }
        Ingridient Create(ItemName name, Image image);
    }
}
