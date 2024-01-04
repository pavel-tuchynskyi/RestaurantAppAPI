using MediatR;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Specifications.MenuItemSpecification;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.CreateJapaneesFood.CreateJapaneesFoodStrategies
{
    public class CreateSusi : IFoodCreator<JapaneesFood>
    {
        private readonly IMenuRepository<JapaneesFood> _foodRepository;
        private readonly IIngridientsRepository<JapaneesFoodIngridient> _ingridientsRepository;

        public string Type => nameof(Susi);

        public CreateSusi(IMenuRepository<JapaneesFood> foodRepository,
            IIngridientsRepository<JapaneesFoodIngridient> ingridientsRepository)
        {
            _foodRepository = foodRepository;
            _ingridientsRepository = ingridientsRepository;
        }

        public async Task<Unit> Create(string name, byte[] imageBlob, string imageType, decimal price, List<Guid> components)
        {
            var susi = new Susi(
                ItemName.Create(name),
                Image.Create(imageBlob, imageType),
                Price.Create(price));

            var ingridients = await _ingridientsRepository.GetAllAsync(
                new IdInRangeSpecification<JapaneesFoodIngridient>(components));

            susi.AddRange(ingridients);

            await _foodRepository.CreateAsync(susi);

            return Unit.Value;
        }
    }
}
