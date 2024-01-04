using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.ItalianFoodMenu.Queries.GetFoodItem
{
    public class GetItalianFoodItemQueryHandler<T> : IRequestHandler<GetItalianFoodItemQuery<T>, FoodItemDto>
        where T : ItalianFood
    {
        private readonly IMenuRepository<T> _foodRepository;

        public GetItalianFoodItemQueryHandler(IMenuRepository<T> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<FoodItemDto> Handle(GetItalianFoodItemQuery<T> request, CancellationToken cancellationToken)
        {
            var item = await _foodRepository.GetByIdAsync<FoodItemDto>(request.Id);

            return item;
        }
    }
}
