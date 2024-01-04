using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.MenuItems.Entities;

namespace RestaurantApp.Application.Common.Helpers
{
    public class FoodCreatorResolver<TFoodType, TIngridientType>
        where TFoodType : MenuItem
        where TIngridientType : Ingridient
    {
        private readonly Dictionary<string, IFoodCreator<TFoodType>> _strategies;
        public FoodCreatorResolver(IMenuRepository<TFoodType> foodRepository,
            IIngridientsRepository<TIngridientType> ingridientsRepository)
        {
            _strategies = StrategyHelper.GetStrategies<string, IFoodCreator<TFoodType>>(typeof(FoodCreatorResolver<,>), foodRepository, ingridientsRepository);
        }

        public IFoodCreator<TFoodType> GetStrategy<T>()
            where T : MenuItem
        {
            var type = typeof(T).Name;

            return _strategies[type];
        }
    }
}
