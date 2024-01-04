using MediatR;
using RestaurantApp.Application.Common.Helpers;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.CreateItalianFood
{
    public class CreateItalianFoodCommandHandler<T> : IRequestHandler<CreateItalianFoodCommand<T>, Unit>
        where T : ItalianFood
    {
        private readonly FoodCreatorResolver<ItalianFood, ItalianFoodIngridient> _foodResolver;

        public CreateItalianFoodCommandHandler(FoodCreatorResolver<ItalianFood, ItalianFoodIngridient> foodResolver)
        {
            _foodResolver = foodResolver;
        }
        public async Task<Unit> Handle(CreateItalianFoodCommand<T> request, CancellationToken cancellationToken)
        {
            var strategy = _foodResolver.GetStrategy<T>();

            var imageBytes = await ImageHelper.SerializeImage(request.Image);
            var imageType = ImageHelper.GetImageType(request.Image);

            var result = await strategy.Create(
                request.Name,
                imageBytes,
                imageType,
                request.Price,
                request.Components);

            return result;
        }
    }
}
