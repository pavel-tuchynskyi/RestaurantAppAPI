using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Users.Entities;
using RestaurantApp.Domain.Users.Events;
using RestaurantApp.Domain.Users.ValueObjects;
using RestaurantApp.Domain.Utils;

namespace RestaurantApp.Domain.Users
{
    public class User : AggregateRoot
    {
        public Name Name { get; private set; }
        public UserEmail Email { get; private set; }
        public Phone PhoneNumber { get; private set; }
        public Password Password { get; private set; }
        public Role Role { get; private set; }

        protected User() { }
        public User(Name name, UserEmail email, Phone phoneNumber, Password password, Role role) : this()
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
            Role = role;

            AddDomainEvent(new UserCreated(this));
        }

        public void AddToRole(Role role)
        {
            if(Role == role)
                return;

            Role = role;
        }

        public void ConfirmEmail(string token)
        {
            Email = Email.Confirm(token);
        }
    }
}
