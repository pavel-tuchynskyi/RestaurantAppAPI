namespace RestaurantApp.Application.Common.DTOs.Account
{
    public record UserCreateDto(string FirstName, string LastName, string Email, string Phone, string Password);
}
