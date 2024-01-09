using MediatR;

namespace RestaurantApp.Application.JapaneesFoodMenu.Commands.DeleteJapaneesFood
{
    public record DeleteJapaneesFoodCommand(Guid Id) : IRequest<Unit>;
}
