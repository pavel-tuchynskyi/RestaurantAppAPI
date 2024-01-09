using MediatR;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Specifications.MenuItemSpecification;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.CreateJapaneesFood.CreateJapaneesFoodStrategies
{
    public class CreateRolls : IFoodCreator<JapaneesFood>
    {
        private readonly IMenuRepository<JapaneesFood> _foodRepository;
        private readonly IIngridientsRepository<JapaneesFoodIngridient> _ingridientsRepository;

        public string Type => nameof(Rolls);

        public CreateRolls(IMenuRepository<JapaneesFood> foodRepository,
            IIngridientsRepository<JapaneesFoodIngridient> ingridientsRepository)
        {
            _foodRepository = foodRepository;
            _ingridientsRepository = ingridientsRepository;
        }

        public async Task<Unit> Create(string name, byte[] imageBlob, string imageType, decimal price, List<Guid> components)
        {
            var ingridients = await _ingridientsRepository.GetAllAsync(
                new IdInRangeSpecification<JapaneesFoodIngridient>(components));

            var rolls = new Rolls(
                ItemName.Create(name),
                Image.Create(imageBlob, imageType),
                Price.Create(price),
                ingridients);

            await _foodRepository.CreateAsync(rolls);

            return Unit.Value;
        }
    }
}
