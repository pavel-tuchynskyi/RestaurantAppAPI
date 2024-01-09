using MediatR;
using RestaurantApp.Application.Common.Interfaces.Account;
using RestaurantApp.Application.Common.Interfaces.MenuItems;
using RestaurantApp.Application.Common.Interfaces.Orders;
using RestaurantApp.Application.Common.Specifications.AccountSpecification;
using RestaurantApp.Application.Common.Specifications.MenuItemSpecification;
using RestaurantApp.Domain.MenuItems;
using RestaurantApp.Domain.Orders;
using RestaurantApp.Domain.Orders.ValueObjects;

namespace RestaurantApp.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Unit>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountService _accountService;
        private readonly IMenuRepository<MenuItem> _menuRepository;
        private readonly Guid _userId;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, 
            IAccountService accountService,
            IMenuRepository<MenuItem> menuRepository,
            IUserContextService userContext)
        {
            _orderRepository = orderRepository;
            _accountService = accountService;
            _menuRepository = menuRepository;
            _userId = userContext.GetUserId();
        }

        public async Task<Unit> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var user = await _accountService.GetUserAsync(new GetUserByIdSpecification(_userId));

            var items = await _menuRepository.GetAllAsync(new IdInRangeSpecification<MenuItem>(request.Items), tracking: true);

            var order = new Order(
                user, 
                OrderAddress.Create(request.City, request.Address), 
                items.Items.ToList());

            await _orderRepository.CreateAsync(order);

            return Unit.Value;
        }
    }
}
