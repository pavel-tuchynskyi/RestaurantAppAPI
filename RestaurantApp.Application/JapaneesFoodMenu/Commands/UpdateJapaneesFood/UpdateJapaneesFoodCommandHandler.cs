using MediatR;
using RestaurantApp.Application.Common.Helpers;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Food.Japanees;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.UpdateJapaneesFood
{
    public class UpdateJapaneesFoodCommandHandler : IRequestHandler<UpdateJapaneesFoodCommand, Unit>
    {
        private readonly IMenuRepository<JapaneesFood> _foodRepository;

        public UpdateJapaneesFoodCommandHandler(IMenuRepository<JapaneesFood> foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public async Task<Unit> Handle(UpdateJapaneesFoodCommand request, CancellationToken cancellationToken)
        {
            var itemToUpdate = await _foodRepository.GetByIdAsync(request.Id, true);

            var imageBytes = await ImageHelper.SerializeImage(request.Image);
            var imageType = ImageHelper.GetImageType(request.Image);

            itemToUpdate.UpdateInformation(
                ItemName.Create(request.Name),
                Image.Create(imageBytes, imageType),
                Price.Create(request.Price));

            await _foodRepository.Update(itemToUpdate);

            return Unit.Value;
        }
    }
}
