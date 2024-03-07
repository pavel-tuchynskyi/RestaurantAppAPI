using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Common.DTOs.Orders;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Application.Orders.Commands.CreateOrder;
using RestaurantApp.Application.Orders.Commands.UpdateOrder;
using RestaurantApp.Application.Orders.Queries.GetOrder;
using RestaurantApp.Application.Orders.Queries.GetOrders;
using RestaurantApp.Web.Contracts.Orders;

namespace RestaurantApp.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class OrdersController : BaseController<OrdersController>
    {
        [HttpPost]
        public async Task<RequestResponse<Unit>> Create(CreateOrderRequest request)
        {
            _logger.LogInformation("Trying to create new order.");

            var command = new CreateOrderCommand(request.City, request.Address, request.Items);

            var result = await Mediator.Send(command);

            _logger.LogInformation("New order successfully created.\n{@Order}", request);

            return new RequestResponse<Unit>(201, result);
        }

        [HttpGet]
        public async Task<RequestResponse<OrderDto>> Get([FromQuery]Guid id)
        {
            _logger.LogInformation($"Requesting order with id {id}");

            var query = new GetOrderQuery(id);

            var result = await Mediator.Send(query);

            _logger.LogInformation("Request of order with id {Id} completed. \n{@Item}", id, result);

            return new RequestResponse<OrderDto>(200, result);
        }

        [HttpPost]
        public async Task<RequestResponse<PagedList<OrderDto>>> GetAll(GetAllOrdersRequest request)
        {
            _logger.LogInformation($"Requesting orders of user {request.UserId}");

            var query = new GetOrdersQuery(request.UserId, request.OrderBy, request.Paging);

            var result = await Mediator.Send(query);

            _logger.LogInformation("Request of orders of user {UserId} completed. Found {@Count} records", request.UserId, result.TotalRecords);

            return new RequestResponse<PagedList<OrderDto>>(200, result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<RequestResponse<Unit>> Update([FromBody]UpdateOrderRequest request)
        {
            _logger.LogInformation($"Trying to update order with id {request.OrderId}");

            var command = new UpdateOrderCommand(request.OrderId, request.City, request.Address, request.Status);
            
            var result = await Mediator.Send(command);

            _logger.LogInformation($"Order with id {request.OrderId} updated successfully");

            return new RequestResponse<Unit>(200, result);
        }
    }
}
