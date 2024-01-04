using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Common.DTOs.Orders;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Orders.Commands.CreateOrder;
using RestaurantApp.Application.Orders.Commands.UpdateOrder;
using RestaurantApp.Application.Orders.Queries.GetOrder;
using RestaurantApp.Application.Orders.Queries.GetOrders;
using RestaurantApp.Web.Common.Extensions;
using RestaurantApp.Web.Contracts.Orders;

namespace RestaurantApp.Web.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        [HttpPost]
        public async Task<RequestResponse<Unit>> Create(CreateOrderRequest request)
        {
            var userId = User.GetUserId();

            var command = new CreateOrderCommand(request.City, request.Address, userId, request.Items);

            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(201, result);
        }

        [HttpGet]
        public async Task<RequestResponse<OrderDto>> Get([FromQuery]Guid id)
        {
            var query = new GetOrderQuery(id);

            var result = await Mediator.Send(query);

            return new RequestResponse<OrderDto>(200, result);
        }

        [HttpPost]
        public async Task<RequestResponse<PagedList<OrderDto>>> GetAll(GetAllOrdersRequest request)
        {
            var query = new GetOrdersQuery(request.UserId, request.OrderBy, request.Paging);

            var result = await Mediator.Send(query);

            return new RequestResponse<PagedList<OrderDto>>(200, result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Update([FromBody]UpdateOrderRequest request)
        {
            var command = new UpdateOrderCommand(request.OrderId, request.City, request.Address, request.Status);
            
            var result = await Mediator.Send(command);

            return new RequestResponse<Unit>(200, result);
        }
    }
}
