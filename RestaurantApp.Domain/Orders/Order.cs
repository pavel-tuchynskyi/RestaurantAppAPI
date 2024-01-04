using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.MenuItems.ValueObjects;
using RestaurantApp.Domain.Orders.ValueObjects;
using RestaurantApp.Domain.Users;

namespace RestaurantApp.Domain.Orders
{
    public class Order : AggregateRoot
    {
        private List<MenuItem> _items = new();
        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        public OrderAddress Address { get; private set; }
        public OrderStatus Status { get; private set; }
        public User CreatedBy { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Price Price { get; private set; }

        protected Order() { }
        public Order(User createdBy, OrderAddress address, List<MenuItem> items) : this()
        {
            CreatedBy = createdBy;
            Address = address;
            Status = OrderStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            AddItems(items);
        }

        public void UpdateInformation(OrderStatus status, OrderAddress address)
        {
            Status = status;
            Address = address;
        }

        public void AddItems(List<MenuItem> items)
        {
            _items.AddRange(items);
            CountPrice();
        }

        private void CountPrice()
        {
            var sum = Items.Sum(x => x.Price.Value);
            Price = Price.Create(sum);
        }
    }
}
