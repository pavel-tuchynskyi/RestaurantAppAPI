using MediatR;
using RestaurantApp.Application.Common.Helpers;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Drink;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.DrinkMenu.Commands.UpdateDrinkItem
{
    public class UpdateDrinkItemCommandHandler : IRequestHandler<UpdateDrinkItemCommand, Unit>
    {
        private readonly IMenuRepository<DrinkMenuItem> _drinkRepository;

        public UpdateDrinkItemCommandHandler(IMenuRepository<DrinkMenuItem> drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        public async Task<Unit> Handle(UpdateDrinkItemCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _drinkRepository.GetByIdAsync(request.Id, true);

            var imageBytes = await ImageHelper.SerializeImage(request.Image);
            var imageType = ImageHelper.GetImageType(request.Image);

            itemToUpdate.UpdateInformation(
                ItemName.Create(request.Name),
                Image.Create(imageBytes, imageType),
                Price.Create(request.Price),
                Description.Create(request.Description));

            await _drinkRepository.Update(itemToUpdate);

            return Unit.Value;
        }
    }
}
