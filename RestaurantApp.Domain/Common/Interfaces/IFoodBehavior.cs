namespace RestaurantApp.Domain.Common.Interfaces
{
    public interface IFoodBehavior<T> where T : Entity
    {
        void AddToCollection(List<T> collection, T item);
        void RemoveFromCollection(List<T> collection, T item);
        void AddRange(List<T> collection, List<T> items);
        void Clear(List<T> items);
    }
}
