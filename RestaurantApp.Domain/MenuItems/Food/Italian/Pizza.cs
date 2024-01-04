using RestaurantApp.Domain.Common.Behaviours;
using RestaurantApp.Domain.Common.Interfaces;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Food.Italian
{
    public class Pizza : ItalianFood, IFoodCommands<ItalianFoodIngridient>
    {
        private FoodBehavior<ItalianFoodIngridient> _ingridientBehavior = new();

        private List<ItalianFoodIngridient> _ingridients = new();
        public IReadOnlyList<ItalianFoodIngridient> Ingridients => _ingridients.AsReadOnly();

        protected Pizza() { }
        public Pizza(ItemName name, Image image, Price price) : base(name, image, price)
        {
        }

        public void Add(ItalianFoodIngridient ingridient)
        {
            _ingridientBehavior.AddToCollection(_ingridients, ingridient);
        }

        public void Remove(ItalianFoodIngridient ingridient)
        {
            _ingridientBehavior.RemoveFromCollection(_ingridients, ingridient);
        }

        public void AddRange(List<ItalianFoodIngridient> ingridients)
        {
            _ingridientBehavior.AddRange(_ingridients, ingridients);
        }
    }
}
