using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Drink
{
    public class Wine : DrinkMenuItem
    {
        protected Wine() { }
        public Wine(ItemName name, Image image, Price price, Description description)
            : base(name, image, price, description)
        {
        }
    }
}
