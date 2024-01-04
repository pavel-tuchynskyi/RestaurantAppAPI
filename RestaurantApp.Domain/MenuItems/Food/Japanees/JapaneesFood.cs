using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Food.Japanees
{
    public abstract class JapaneesFood : MenuItem
    {
        protected JapaneesFood() { }
        public JapaneesFood(ItemName name, Image image, Price price) : base(name, image, price)
        {
        }
    }
}
