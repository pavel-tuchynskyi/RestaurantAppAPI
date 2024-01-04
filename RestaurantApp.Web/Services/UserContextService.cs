using RestaurantApp.Application.Common.Interfaces.Account;
using System.ComponentModel;
using System.Security.Claims;

namespace RestaurantApp.Web.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public UserContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid GetUserId()
        {
            var principal = _contextAccessor.HttpContext.User;
            if (principal == null || principal.Identity == null ||
                !principal.Identity.IsAuthenticated)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var converter = TypeDescriptor.GetConverter(typeof(Guid));

            var id = (Guid)converter.ConvertFromInvariantString(userId);

            return id;
        }
    }
}
