using MediatR;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Specifications.MenuItemSpecification;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Italian;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.CreateItalianFood.CreateItalianFoodStrategies
{
    public class CreatePizza : IFoodCreator<ItalianFood>
    {
        private readonly IMenuRepository<ItalianFood> _foodRepository;
        private readonly IIngridientsRepository<ItalianFoodIngridient> _ingridientsRepository;

        public string Type => nameof(Pizza);

        public CreatePizza(IMenuRepository<ItalianFood> foodRepository,
            IIngridientsRepository<ItalianFoodIngridient> ingridientsRepository)
        {
            _foodRepository = foodRepository;
            _ingridientsRepository = ingridientsRepository;
        }

        public async Task<Unit> Create(string name, byte[] imageBlob, string imageType, decimal price, List<Guid> components)
        {
            var pizza = new Pizza(
                ItemName.Create(name),
                Image.Create(imageBlob, imageType),
                Price.Create(price));

            var ingridients = await _ingridientsRepository.GetAllAsync(
                new IdInRangeSpecification<ItalianFoodIngridient>(components));

            pizza.AddRange(ingridients);

            await _foodRepository.CreateAsync(pizza);

            return Unit.Value;
        }
    }
}
