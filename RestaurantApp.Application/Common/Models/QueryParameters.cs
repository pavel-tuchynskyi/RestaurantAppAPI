namespace RestaurantApp.Application.Common.Models
{
    public record QueryParameters (Search Search, OrderBy OrderBy, Paging Paging);

    public record Search (string SearchParameter, string SearchTerm);

    public record OrderBy (string Value, bool Ascending = true);

    public record Paging (int PageNumber, int PageSize);
}
