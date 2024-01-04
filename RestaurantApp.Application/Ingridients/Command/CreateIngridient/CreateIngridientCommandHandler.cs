using MediatR;
using RestaurantApp.Application.Common.Builders.IngridientBuilder;
using RestaurantApp.Application.Common.Helpers;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Entities;

namespace RestaurantApp.Application.Ingridients.Command.CreateIngridient
{
    public class CreateIngridientCommandHandler<T> : IRequestHandler<CreateIngridientCommand<T>, Unit>
        where T : Ingridient
    {
        private readonly IIngridientsRepository<Ingridient> _ingridientsRepository;

        public CreateIngridientCommandHandler(IIngridientsRepository<Ingridient> ingridientsRepository)
        {
            _ingridientsRepository = ingridientsRepository;
        }

        public async Task<Unit> Handle(CreateIngridientCommand<T> request, CancellationToken cancellationToken)
        {
            var imageBytes = await ImageHelper.SerializeImage(request.Image);
            var imageFormat = ImageHelper.GetImageType(request.Image);

            var ingridient = new IngridientBuilder()
                .SetName(request.Name)
                .SetImage(imageBytes, imageFormat)
                .Create<T>();

            await _ingridientsRepository.CreateAsync(ingridient);

            return Unit.Value;
        }
    }
}
