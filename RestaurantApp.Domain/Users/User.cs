using RestaurantApp.Domain.Common;
using RestaurantApp.Domain.Users.Entities;
using RestaurantApp.Domain.Users.ValueObjects;

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
        public User(Name name, UserEmail email, Phone phoneNumber, Password password) : this()
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public void AddToRole(Role role)
        {
            if(Role == role)
                return;

            Role = role;
        }

        public void ChangePassword(Password password)
        {
            if(Password != password) 
                return;

            Password = password;
        }

        public void ChangeName(string firstName, string lastName)
        {
            Name = Name.Create(firstName, lastName);
        }

        public void ChangeEmail(string email)
        {
            Email = UserEmail.Create(email);
        }
    }
}
