using MediatR;
using RestaurantApp.Application.Common.Interfaces.Orders;
using RestaurantApp.Domain.Orders.ValueObjects;

namespace RestaurantApp.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId, true);

            order.UpdateInformation(request.Status, OrderAddress.Create(request.City, request.Address));

            await _orderRepository.Update(order);

            return Unit.Value;
        }
    }
}
