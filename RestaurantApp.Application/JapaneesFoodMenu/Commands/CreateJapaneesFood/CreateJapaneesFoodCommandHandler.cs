using MediatR;
using RestaurantApp.Application.Common.Helpers;
using RestaurantApp.Domain.MenuItems.Entities;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.CreateJapaneesFood
{
    public class CreateJapaneesFoodCommandHandler<T> : IRequestHandler<CreateJapaneesFoodCommand<T>, Unit>
        where T : JapaneesFood
    {
        private readonly FoodCreatorResolver<JapaneesFood, JapaneesFoodIngridient> _foodResolver;

        public CreateJapaneesFoodCommandHandler(FoodCreatorResolver<JapaneesFood, JapaneesFoodIngridient> foodResolver)
        {
            _foodResolver = foodResolver;
        }
        public async Task<Unit> Handle(CreateJapaneesFoodCommand<T> request, CancellationToken cancellationToken)
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
