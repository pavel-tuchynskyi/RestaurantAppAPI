using System.ComponentModel;
using System.Security.Claims;

namespace RestaurantApp.Web.Common.Extensions
{
    public static class UserClaimsExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal principal)
        {
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
