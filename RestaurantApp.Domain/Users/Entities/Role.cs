using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Users.ValueObjects;

namespace RestaurantApp.Domain.Users.Entities
{
    public class Role : Entity
    {
        public RoleName Name { get; private set; }

        protected Role() { }
        public Role(RoleName name)
        {
            Name = name;
        }
    }
}
