using RestaurantApp.Domain.Common.Interfaces;
using IvalidDataException = RestaurantApp.Domain.Common.Exceptions.InvalidDataException;

namespace RestaurantApp.Domain.Common.Behaviours
{
    public class FoodBehavior<T> : IFoodBehavior<T> where T : Entity
    {
        public void AddToCollection(List<T> items, T item)
        {
            if (items.Contains(item))
            {
                return;
            }

            items.Add(item);
        }
        public void RemoveFromCollection(List<T> items, T item)
        {
            var itemToRemove = items.FirstOrDefault(x => x == item);

            if (itemToRemove is null)
            {
                throw new IvalidDataException("Can't find this item");
            }

            items.Remove(itemToRemove);
        }
        public void AddRange(List<T> items, List<T> itemsToAdd)
        {
            if (items.Any())
            {
                itemsToAdd = items.Except(itemsToAdd).ToList();
            }

            items.AddRange(itemsToAdd);
        }

        public void Clear(List<T> items)
        {
            if (items.Any())
            {
                items.Clear();
            }
        }
    }
}
