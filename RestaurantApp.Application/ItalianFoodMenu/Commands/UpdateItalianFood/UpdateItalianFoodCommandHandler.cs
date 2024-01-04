using MediatR;
using RestaurantApp.Application.Common.Helpers;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Food.Italian;
using RestaurantApp.Domain.MenuItems.ValueObjects;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.UpdateItalianFood
{
    public class UpdateItalianFoodCommandHandler : IRequestHandler<UpdateItalianFoodCommand, Unit>
    {
        private readonly IMenuRepository<ItalianFood> _foodRepository;

        public UpdateItalianFoodCommandHandler(IMenuRepository<ItalianFood> foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public async Task<Unit> Handle(UpdateItalianFoodCommand request, CancellationToken cancellationToken)
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
