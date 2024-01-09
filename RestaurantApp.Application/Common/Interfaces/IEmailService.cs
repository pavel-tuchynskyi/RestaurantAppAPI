using RestaurantApp.Application.Common.Models;

namespace RestaurantApp.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage message);
    }
}
