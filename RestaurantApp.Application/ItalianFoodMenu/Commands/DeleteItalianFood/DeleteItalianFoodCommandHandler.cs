using MediatR;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Food.Italian;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.DeleteItalianFood
{
    public class DeleteItalianFoodCommandHandler : IRequestHandler<DeleteItalianFoodCommand, Unit>
    {
        private readonly IMenuRepository<ItalianFood> _foodRepository;

        public DeleteItalianFoodCommandHandler(IMenuRepository<ItalianFood> foodRepository)
        {
            _foodRepository = foodRepository;
        }
        public async Task<Unit> Handle(DeleteItalianFoodCommand request, CancellationToken cancellationToken)
        {
            await _foodRepository.Delete(request.id);

            return Unit.Value;
        }
    }
}
