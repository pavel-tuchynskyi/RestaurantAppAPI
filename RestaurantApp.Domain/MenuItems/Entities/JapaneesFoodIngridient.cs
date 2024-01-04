using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Entities
{
    public class JapaneesFoodIngridient : Ingridient
    {
        protected JapaneesFoodIngridient() { }
        public JapaneesFoodIngridient(ItemName name, Image image) : base(name, image){}
    }
}
