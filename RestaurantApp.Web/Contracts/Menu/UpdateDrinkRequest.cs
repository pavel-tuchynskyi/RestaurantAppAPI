namespace RestaurantApp.Web.Contracts.Menu
{
    public record UpdateDrinkRequest(
        string Name,
        IFormFile Image,
        decimal Price,
        string Description);
}
