using RestaurantApp.Application.Common.Interfaces;

namespace RestaurantApp.Infrastructure.Configuration
{
    public class ClientUrl : IClientUrlSettings
    {
        public string BaseUrl { get; set; }
        public Dictionary<string, string> Path { get; set; }
    }
}
