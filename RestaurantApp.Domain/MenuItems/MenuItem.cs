using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.MenuItems.ValueObjects;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.MenuItems
{
    public abstract class MenuItem : AggregateRoot
    {
        public ItemName Name { get; protected set; }
        public Image Image { get; protected set; }
        public Price Price { get; protected set; }

        protected MenuItem() { }
        public MenuItem(ItemName name, Image image, Price price) : this()
        {
            Name = name;
            Image = image;
            Price = price;
        }

        public virtual void UpdateInformation(ItemName name, Image image, Price price)
        {
            Guard.Is(name, nameof(Name)).NotNull();
            Guard.Is(image, nameof(Image)).NotNull();
            Guard.Is(price, nameof(Price)).NotNull();

            Name = name;
            Image = image;
            Price = price;
        }
    }
}
