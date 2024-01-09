using RestaurantApp.Domain.Common.Behaviours;
using RestaurantApp.Domain.Common.Enums;
using RestaurantApp.Domain.Common.Interfaces;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Food.Japanees
{
    public class Rolls : JapaneesFood, IFoodCommands<JapaneesFoodIngridient>
    {
        private FoodBehavior<JapaneesFoodIngridient> _ingridientBehavior = new();

        private List<JapaneesFoodIngridient> _ingridients = new();
        public IReadOnlyList<JapaneesFoodIngridient> Ingridients => _ingridients.AsReadOnly();

        protected Rolls() { }
        public Rolls(ItemName name, Image image, Price price, List<JapaneesFoodIngridient> ingridients) 
            : base(name, image, price)
        {
            AddRange(ingridients);
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
