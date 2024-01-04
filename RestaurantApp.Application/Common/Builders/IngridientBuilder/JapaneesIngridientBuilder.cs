using RestaurantApp.Application.Common.Enums;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.Common.Builders.IngridientBuilder
{
    public class JapaneesIngridientBuilder : IIngridientBuilder
    {
        public Type Type => typeof(JapaneesFoodIngridient);

        public Ingridient Create(ItemName name, Image image)
        {
            return new JapaneesFoodIngridient(name, image);
        }
    }
}
