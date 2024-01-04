using MediatR;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.DeleteItalianFood
{
    public record DeleteItalianFoodCommand(Guid id) : IRequest<Unit>;
}
