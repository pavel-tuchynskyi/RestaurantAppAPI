using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications.MenuItemSpecification;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFood
{
    public class GetJapaneesFoodQueryHandler<T> : IRequestHandler<GetJapaneesFoodQuery<T>, PagedList<FoodItemDto>>
        where T : JapaneesFood
    {
        private readonly IMenuRepository<T> _foodRepository;

        public GetJapaneesFoodQueryHandler(IMenuRepository<T> foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public async Task<PagedList<FoodItemDto>> Handle(GetJapaneesFoodQuery<T> request, CancellationToken cancellationToken)
        {
            var items = await _foodRepository.GetAllAsync<FoodItemDto>(
                new MenuItemSearchSpecification<T>(request.Search.SearchParameter, request.Search.SearchTerm),
                request.OrderBy.Value,
                request.OrderBy.Ascending,
                request.Paging.PageNumber,
                request.Paging.PageSize);

            return items;
        }
    }
}
