using RestaurantApp.Domain.MenuItems.ValueObjects;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.MenuItems.Drink
{
    public abstract class DrinkMenuItem : MenuItem
    {
        public Description Description { get; private set; }

        protected DrinkMenuItem() { }
        public DrinkMenuItem(ItemName name, Image image, Price price, Description description) : base(name, image, price)
        {
            Name = name;
            Image = image;
            Description = description;
            Price = price;
        }

        public void UpdateInformation(ItemName name, Image image, Price price, Description description)
        {
            Guard.Is(description, nameof(Description)).NotNull();
            Description = description;

            base.UpdateInformation(name, image, price);
        }
    }
}
