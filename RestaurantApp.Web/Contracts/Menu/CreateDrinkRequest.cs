namespace RestaurantApp.Web.Contracts.Menu
{
    public record CreateDrinkRequest(
        string Name,
        IFormFile Image,
        decimal Price,
        string Description);
}
