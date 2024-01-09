using MediatR;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Food.Japanees;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.DeleteJapaneesFood
{
    public class DeleteJapaneesFoodCommandHandler : IRequestHandler<DeleteJapaneesFoodCommand, Unit>
    {
        private readonly IMenuRepository<JapaneesFood> _foodRepository;

        public DeleteJapaneesFoodCommandHandler(IMenuRepository<JapaneesFood> foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public async Task<Unit> Handle(DeleteJapaneesFoodCommand request, CancellationToken cancellationToken)
        {
            await _foodRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
