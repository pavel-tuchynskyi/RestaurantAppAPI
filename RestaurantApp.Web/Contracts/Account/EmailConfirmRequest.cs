namespace RestaurantApp.Web.Contracts.Account
{
    public record EmailConfirmRequest(Guid id, string token);
}
