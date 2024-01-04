using RestaurantApp.Domain.Common.Behaviours;
using RestaurantApp.Domain.Common.Interfaces;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Food.Japanees
{
    public class Susi : JapaneesFood, IFoodCommands<JapaneesFoodIngridient>
    {
        private FoodBehavior<JapaneesFoodIngridient> _ingridientBehavior = new();

        private List<JapaneesFoodIngridient> _ingridients = new();
        public IReadOnlyList<JapaneesFoodIngridient> Ingridients => _ingridients.AsReadOnly();

        protected Susi() { }
        public Susi(ItemName name, Image image, Price price)
            : base(name, image, price)
        {
        }

        public void Add(JapaneesFoodIngridient ingridient)
        {
            _ingridientBehavior.AddToCollection(_ingridients, ingridient);
        }

        public void Remove(JapaneesFoodIngridient ingridient)
        {
            _ingridientBehavior.RemoveFromCollection(_ingridients, ingridient);
        }

        public void AddRange(List<JapaneesFoodIngridient> ingridients)
        {
            _ingridientBehavior.AddRange(_ingridients, ingridients);
        }
    }
}
