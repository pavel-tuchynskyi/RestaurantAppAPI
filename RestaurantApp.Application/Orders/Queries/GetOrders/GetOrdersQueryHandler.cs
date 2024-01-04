using MediatR;
using Microsoft.AspNetCore.Http;
using RestaurantApp.Application.Common.DTOs.Orders;
using RestaurantApp.Application.Common.Exceptions;
using RestaurantApp.Application.Common.Interfaces.Account;
using RestaurantApp.Application.Common.Interfaces.Orders;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Common.Specifications.OrdersSpecification;
using RestaurantApp.Domain.Users.ValueObjects;

namespace RestaurantApp.Application.Orders.Queries.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, PagedList<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAccountService _accountService;
        private readonly Guid _userId;

        public GetOrdersQueryHandler(IOrderRepository orderRepository, 
            IAccountService accountService, 
            IUserContextService userContext)
        {
            _orderRepository = orderRepository;
            _accountService = accountService;
            _userId = userContext.GetUserId();
        }
        public async Task<PagedList<OrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            if (_userId != request.UserId 
                && !await _accountService.IsUserInRoleAsync(_userId, RoleName.Admin))
            {
                throw new ForbiddenRequestException("Access denied");
            }

            var orders = await _orderRepository.GetAllAsync<OrderDto>(
                new UserOrdersSpecification(request.UserId),
                request.OrderBy.Value,
                request.OrderBy.Ascending,
                request.Paging.PageNumber,
                request.Paging.PageSize);

            return orders;
        }
    }
}
