using MediatR;
using RestaurantApp.Application.Common.Builders;
using RestaurantApp.Application.Common.Interfaces;
using RestaurantApp.Application.Common.Models;
using RestaurantApp.Domain.Users.Events;
using System.Web;

namespace RestaurantApp.Application.Account.Events
{
    public class UserCreatedEventHandler: INotificationHandler<UserCreated>
    {
        private readonly IEmailService _emailService;
        private readonly ITemplateService _templateService;
        private readonly IClientUrlSettings _clientUrl;

        public UserCreatedEventHandler(IEmailService emailService, ITemplateService templateService,
            IClientUrlSettings clientUrl)
        {
            _emailService = emailService;
            _templateService = templateService;
            _clientUrl = clientUrl;
        }

        public async Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            var template = await _templateService.GetTemplate("ConfirmEmail");

            var builder = new UriPathBuilder(_clientUrl.BaseUrl);

            builder.SetPath(_clientUrl.Path["ConfirmEmail"]);

            var token = HttpUtility.HtmlEncode(notification.User.Email.EmailConfirmationToken);
            var queryParams = new Dictionary<string, string>()
            {
                { "id", notification.User.Id.ToString() },
                { "token", token }
            };

            builder.SetQuery(queryParams);

            template = _templateService.ReplaceValues(template, notification.User.Name.FirstName, builder.Build());

            var email = new EmailMessage(notification.User.Email, "Email Confirmation", template);

            await _emailService.SendAsync(email);
        }
    }
}
