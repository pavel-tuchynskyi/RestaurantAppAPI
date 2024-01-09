using MediatR;

namespace RestaurantApp.Application.ItalianFoodMenu.Commands.DeleteItalianFood
{
    public record DeleteItalianFoodCommand(Guid Id) : IRequest<Unit>;
}
