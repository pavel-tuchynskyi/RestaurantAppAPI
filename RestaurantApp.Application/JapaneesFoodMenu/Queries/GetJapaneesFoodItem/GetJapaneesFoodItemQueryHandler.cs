using MediatR;
using RestaurantApp.Application.Common.DTOs.Menu;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.JapaneesFoodMenu.Queries.GetJapaneesFoodItem
{
    public class GetJapaneesFoodItemQueryHandler<T> : IRequestHandler<GetJapaneesFoodItemQuery<T>, FoodItemDto>
        where T : JapaneesFood
    {
        private readonly IMenuRepository<T> _foodRepository;

        public GetJapaneesFoodItemQueryHandler(IMenuRepository<T> foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<FoodItemDto> Handle(GetJapaneesFoodItemQuery<T> request, CancellationToken cancellationToken)
        {
            var item = await _foodRepository.GetByIdAsync<FoodItemDto>(request.Id);

            return item;
        }
    }
}
