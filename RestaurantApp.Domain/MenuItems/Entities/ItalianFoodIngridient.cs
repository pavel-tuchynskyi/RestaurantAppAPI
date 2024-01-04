using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Entities
{
    public class ItalianFoodIngridient : Ingridient
    {
        protected ItalianFoodIngridient() { }
        public ItalianFoodIngridient(ItemName name, Image image) : base(name, image) { }
    }
}
