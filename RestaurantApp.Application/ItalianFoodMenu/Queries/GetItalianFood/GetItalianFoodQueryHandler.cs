using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications.MenuItemSpecification;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.ItalianFoodMenu.Queries.GetItalianFood
{
    public class GetItalianFoodQueryHandler<T> : IRequestHandler<GetItalianFoodQuery<T>, PagedList<FoodItemDto>>
        where T : ItalianFood
    {
        private readonly IMenuRepository<T> _foodRepository;

        public GetItalianFoodQueryHandler(IMenuRepository<T> foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public async Task<PagedList<FoodItemDto>> Handle(GetItalianFoodQuery<T> request, CancellationToken cancellationToken)
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
