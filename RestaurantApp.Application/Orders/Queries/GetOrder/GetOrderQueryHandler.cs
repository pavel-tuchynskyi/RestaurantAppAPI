using AutoMapper;
using MediatR;
using RestaurantApp.Application.Common.DTOs.Orders;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Interfaces.Account;
using RestaurantApp.Application.Common.Interfaces.Orders;
using RestaurantApp.Domain.Orders;
using RestaurantApp.Domain.Users.ValueObjects;

namespace RestaurantApp.Application.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly Guid _userId;

        public GetOrderQueryHandler(IOrderRepository orderRepository, 
            IAccountService accountService, 
            IUserContextService userContext,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _accountService = accountService;
            _mapper = mapper;
            _userId = userContext.GetUserId();
        }

        public async Task<OrderDto> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);

            if (order.CreatedBy.Id != _userId 
                && !await _accountService.IsUserInRoleAsync(_userId, RoleName.Admin))
            {
                throw new ForbiddenRequestException("Access denied");
            }

            return _mapper.Map<Order, OrderDto>(order);
        }
    }
}
