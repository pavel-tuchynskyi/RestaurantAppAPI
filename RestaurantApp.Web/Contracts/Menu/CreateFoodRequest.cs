namespace RestaurantApp.Web.Contracts.Menu
{
    public record CreateFoodRequest(
        string Name,
        IFormFile Image,
        decimal Price,
        List<Guid> Components);
}
