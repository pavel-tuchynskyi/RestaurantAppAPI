using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Drink
{
    public class Beer : DrinkMenuItem
    {
        protected Beer() { }
        public Beer(ItemName name, Image image, Price price, Description description)
            : base(name, image, price, description)
        {
        }
    }
}
