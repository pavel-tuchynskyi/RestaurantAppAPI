using MediatR;
using RestaurantApp.Domain.MenuItems;

namespace RestaurantApp.Application.Common.Interfaces.MenuItems
{
    public interface IFoodCreator<T> where T : MenuItem
    {
        string Type { get; }
        Task<Unit> Create(string name, byte[] imageBlob, string imageType, decimal price, List<Guid> components);
    }
}
