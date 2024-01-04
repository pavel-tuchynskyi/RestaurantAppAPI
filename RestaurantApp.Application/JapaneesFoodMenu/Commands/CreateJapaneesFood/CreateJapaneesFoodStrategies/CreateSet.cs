using MediatR;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Specifications.MenuItemSpecification;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.CreateJapaneesFood.CreateJapaneesFoodStrategies
{
    public class CreateSet : IFoodCreator<JapaneesFood>
    {
        private readonly IMenuRepository<JapaneesFood> _foodRepository;
        private readonly IIngridientsRepository<JapaneesFoodIngridient> _ingridientsRepository;

        public string Type => nameof(Set);

        public CreateSet(IMenuRepository<JapaneesFood> foodRepository,
            IIngridientsRepository<JapaneesFoodIngridient> ingridientsRepository)
        {
            _foodRepository = foodRepository;
            _ingridientsRepository = ingridientsRepository;
        }

        public async Task<Unit> Create(string name, byte[] imageBlob, string imageType, decimal price, List<Guid> components)
        {
            var set = new Set(
                ItemName.Create(name),
                Image.Create(imageBlob, imageType),
                Price.Create(price));

            var setComponents = await _foodRepository.GetAllAsync(
                new IdInRangeSpecification<JapaneesFood>(components)
                .And(new IsTypeOfSpecification<JapaneesFood, Susi>())
                .Or(new IsTypeOfSpecification<JapaneesFood, Rolls>()),
                tracking: true);

            set.AddRange(setComponents.Items.ToList());

            await _foodRepository.CreateAsync(set);

            return Unit.Value;
        }
    }
}
