using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Drink
{
    public class NonAlcohol : DrinkMenuItem
    {
        protected NonAlcohol() { }
        public NonAlcohol(ItemName name, Image image, Price price, Description description)
            : base(name, image, price, description)
        {
        }
    }
}
