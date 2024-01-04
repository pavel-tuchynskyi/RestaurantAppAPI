using MediatR;
using RestaurantApp.Application.Common.Builders.DrinkBuilder;
using RestaurantApp.Application.Common.Helpers;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Commands.CreateDrinkItem
{
    public class CreateDrinkItemCommandHandler<T> : IRequestHandler<CreateDrinkItemCommand<T>, Unit>
        where T : DrinkMenuItem
    {
        private readonly IMenuRepository<DrinkMenuItem> _drinkRepository;

        public CreateDrinkItemCommandHandler(IMenuRepository<DrinkMenuItem> drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public async Task<Unit> Handle(CreateDrinkItemCommand<T> request, CancellationToken cancellationToken)
        {
            var imageBytes = await ImageHelper.SerializeImage(request.Image);
            var imageFormat = ImageHelper.GetImageType(request.Image);

            var item = new DrinkItemBuilder()
                .SetName(request.Name)
                .SetImage(imageBytes, imageFormat)
                .SetPrice(request.Price)
                .SetDescription(request.Description)
                .Create<T>();

            await _drinkRepository.CreateAsync(item);

            return Unit.Value;
        }
    }
}
