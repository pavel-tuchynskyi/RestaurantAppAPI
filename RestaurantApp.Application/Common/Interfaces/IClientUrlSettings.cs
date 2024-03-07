namespace RestaurantApp.Application.Common.Interfaces
{
    public interface IClientUrlSettings
    {
        string BaseUrl { get; set; }
        Dictionary<string, string> Path { get; set; }
    }
}
