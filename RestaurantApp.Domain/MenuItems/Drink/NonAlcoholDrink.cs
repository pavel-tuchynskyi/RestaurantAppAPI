using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Drink
{
    public class NonAlcoholDrink : DrinkMenuItem
    {
        protected NonAlcoholDrink() { }
        public NonAlcoholDrink(ItemName name, Image image, Price price, Description description)
            : base(name, image, price, description)
        {
        }
    }
}
