using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItem
{
    public class GetDrinkItemQueryHandler<T> : IRequestHandler<GetDrinkItemQuery<T>, DrinkItemDto>
        where T : DrinkMenuItem
    {
        private readonly IMenuRepository<T> _drinkRepository;

        public GetDrinkItemQueryHandler(IMenuRepository<T> drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        public async Task<DrinkItemDto> Handle(GetDrinkItemQuery<T> request, CancellationToken cancellationToken)
        {
            var item = await _drinkRepository.GetByIdAsync<DrinkItemDto>(request.Id);

            return item;
        }
    }
}
