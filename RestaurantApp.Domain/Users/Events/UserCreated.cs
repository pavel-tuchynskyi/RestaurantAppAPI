using RestaurantApp.Domain.Common.Interfaces;

namespace RestaurantApp.Domain.Users.Events
{
    public record UserCreated(User User) : IDomainEvent;
}
