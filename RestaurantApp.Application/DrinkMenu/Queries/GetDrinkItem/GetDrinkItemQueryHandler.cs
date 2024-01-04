using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItem
{
    public class GetDrinkItemQueryHandler : IRequestHandler<GetDrinkItemQuery, DrinkItemDto>
    {
        private readonly IMenuRepository<DrinkMenuItem> _drinkRepository;

        public GetDrinkItemQueryHandler(IMenuRepository<DrinkMenuItem> drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        public async Task<DrinkItemDto> Handle(GetDrinkItemQuery request, CancellationToken cancellationToken)
        {
            var item = await _drinkRepository.GetByIdAsync<DrinkItemDto>(request.Id);

            return item;
        }
    }
}
