using RestaurantApp.Domain.Common.Interfaces;

namespace RestaurantApp.Domain.Orders.Events
{
    public record OrderCreated (Order Order) : IDomainEvent;
}
