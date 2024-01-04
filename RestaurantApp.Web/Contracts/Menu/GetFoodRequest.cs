using RestaurantApp.Application.Common.Models;

namespace RestaurantApp.Web.Contracts.Menu
{
    public record GetFoodRequest : QueryParameters
    {
        public GetFoodRequest(Search Search, OrderBy OrderBy, Paging Paging) : base(Search, OrderBy, Paging)
        {
        }
    }
}
