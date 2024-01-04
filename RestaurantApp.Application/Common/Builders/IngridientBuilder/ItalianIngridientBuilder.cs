using RestaurantApp.Application.Common.Enums;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.Common.Builders.IngridientBuilder
{
    public class ItalianIngridientBuilder : IIngridientBuilder
    {
        public Type Type => typeof(ItalianFoodIngridient);

        public Ingridient Create(ItemName name, Image image)
        {
            return new ItalianFoodIngridient(name, image);
        }
    }
}
