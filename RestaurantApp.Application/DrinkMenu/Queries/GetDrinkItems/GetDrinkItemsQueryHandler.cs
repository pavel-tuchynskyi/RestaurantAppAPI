using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications.MenuItemSpecification;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Queries.GetDrinkItems
{
    public class GetDrinkItemsQueryHandler<T> : IRequestHandler<GetDrinkItemsQuery<T>, PagedList<DrinkItemDto>>
        where T : DrinkMenuItem
    {
        private readonly IMenuRepository<T> _drinkRepository;

        public GetDrinkItemsQueryHandler(IMenuRepository<T> drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        public async Task<PagedList<DrinkItemDto>> Handle(GetDrinkItemsQuery<T> request, CancellationToken cancellationToken)
        {
            var items = await _drinkRepository.GetAllAsync<DrinkItemDto>(
                new MenuItemSearchSpecification<T>(request.Search.SearchParameter, request.Search.SearchTerm),
                request.OrderBy.Value,
                request.OrderBy.Ascending,
                request.Paging.PageNumber,
                request.Paging.PageSize);

            return items;
        }
    }
}
