using RestaurantApp.Domain.Common.Behaviours;
using RestaurantApp.Domain.Common.Interfaces;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Domain.MenuItems.Food.Japanees
{
    public class Set : JapaneesFood, IFoodCommands<JapaneesFood>
    {
        private FoodBehavior<JapaneesFood> _setBehavior = new();

        private List<JapaneesFood> _ingridients = new List<JapaneesFood>();
        public IReadOnlyList<JapaneesFood> Ingridients => _ingridients.AsReadOnly();

        protected Set() { }
        public Set(ItemName name, Image image, Price price, List<JapaneesFood> japaneesFoods) : base(name, image, price)
        {          
        }

        public void Add(JapaneesFood item)
        {
            _setBehavior.AddToCollection(_ingridients, item);
            Price += item.Price;
        }

        public void Remove(JapaneesFood item)
        {
            _setBehavior.RemoveFromCollection(_ingridients, item);
            Price -= item.Price;
        }

        public void AddRange(List<JapaneesFood> items)
        {
            _setBehavior.AddRange(_ingridients, items);
            var sum = items.Sum(i => i.Price.Value);
            Price += sum;
        }
    }
}
