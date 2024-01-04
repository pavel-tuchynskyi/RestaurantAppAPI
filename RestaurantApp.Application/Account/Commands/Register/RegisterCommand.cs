﻿using MediatR;

namespace RestaurantApp.Application.Account.Commands.Register
{
    public class RegisterCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}
