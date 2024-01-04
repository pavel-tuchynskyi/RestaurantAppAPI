namespace RestaurantApp.Domain.Common.Interfaces
{
    public interface IFoodCommands<T> where T : Entity
    {
        void Add(T item);
        void Remove(T item);
        void AddRange(List<T> items);
    }
}
