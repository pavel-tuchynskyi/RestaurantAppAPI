using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Entities
{
    public abstract class Ingridient : Entity
    {
        public ItemName Name { get; private set; }
        public Image Image { get; private set; }

        protected Ingridient() { }
        public Ingridient(ItemName name, Image image) : this()
        {
            Name = name;
            Image = image;
        }
    }
}
