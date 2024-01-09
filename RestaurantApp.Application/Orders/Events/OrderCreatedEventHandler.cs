using MediatR;
using RestaurantApp.Application.Common.Interfaces;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Domain.Orders.Events;

namespace RestaurantApp.Application.Orders.Events
{
    public class OrderCreatedEventHandler : INotificationHandler<OrderCreated>
    {
        private readonly IEmailService _emailService;
        private readonly ITemplateService _templateService;

        public OrderCreatedEventHandler(IEmailService emailService, ITemplateService templateService)
        {
            _emailService = emailService;
            _templateService = templateService;
        }
        public async Task Handle(OrderCreated notification, CancellationToken cancellationToken)
        {
            var template = await _templateService.GetTemplate("OrderCreated");

            var order = notification.Order;

            template = _templateService.ReplaceValues(
                template,
                order.CreatedBy.Name.FirstName,
                order.Address.Address,
                order.Id.ToString());

            var email = new EmailMessage(notification.Order.CreatedBy.Email, "Thanks for order", template);

            await _emailService.SendAsync(email);
        }
    }
}
