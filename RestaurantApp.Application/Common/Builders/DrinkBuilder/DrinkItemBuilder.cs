using RestaurantApp.Domain.MenuItems.Drink;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.Common.Builders.DrinkBuilder
{
    public class DrinkItemBuilder
    {
        private ItemName Name { get; set; }
        private Image Image { get; set; }
        private Price Price { get; set; }
        private Description Description { get; set; }

        public DrinkMenuItem Create<T>()
            where T : DrinkMenuItem
        {
            var drinkItem = (DrinkMenuItem)Activator
                .CreateInstance(typeof(T), Name, Image, Price, Description);

            return drinkItem;
        }

        public DrinkItemBuilder SetName(string name)
        {
            Name = ItemName.Create(name);
            return this;
        }

        public DrinkItemBuilder SetImage(byte[] imageBlob, string format)
        {
            Image = Image.Create(imageBlob, format);
            return this;
        }

        public DrinkItemBuilder SetPrice(decimal price)
        {
            Price = Price.Create(price);
            return this;
        }

        public DrinkItemBuilder SetDescription(string description)
        {
            Description = Description.Create(description);
            return this;
        }
    }
}
