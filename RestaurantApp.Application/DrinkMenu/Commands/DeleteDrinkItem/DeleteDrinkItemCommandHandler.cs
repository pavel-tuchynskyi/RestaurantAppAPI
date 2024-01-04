using MediatR;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Domain.MenuItems.Drink;

namespace RestaurantApp.Application.DrinkMenu.Commands.DeleteDrinkItem
{
    public class DeleteDrinkItemCommandHandler : IRequestHandler<DeleteDrinkItemCommand, Unit>
    {
        private readonly IMenuRepository<DrinkMenuItem> _drinkRepository;

        public DeleteDrinkItemCommandHandler(IMenuRepository<DrinkMenuItem> drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }
        public async Task<Unit> Handle(DeleteDrinkItemCommand request, CancellationToken cancellationToken)
        {
            await _drinkRepository.Delete(request.Id);

            return Unit.Value;
        }
    }
}
