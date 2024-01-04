namespace RestaurantApp.Web.Contracts.Menu
{
    public record UpdateFoodRequest (string Name, IFormFile Image, decimal Price);
}
