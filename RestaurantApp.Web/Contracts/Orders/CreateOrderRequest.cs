namespace RestaurantApp.Web.Contracts.Orders
{
    public record CreateOrderRequest(
        string City,
        string Address,
        List<Guid> Items
        );
}
