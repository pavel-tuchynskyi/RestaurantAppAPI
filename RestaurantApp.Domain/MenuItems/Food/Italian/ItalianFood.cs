using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Food.Italian
{
    public abstract class ItalianFood : MenuItem
    {
        protected ItalianFood() { }
        public ItalianFood(ItemName name, Image image, Price price) : base(name, image, price)
        {
            Name = name;
            Image = image;
            Price = price;
        }
    }
}
