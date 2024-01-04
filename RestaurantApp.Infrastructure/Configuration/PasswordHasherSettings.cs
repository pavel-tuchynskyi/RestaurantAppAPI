namespace RestaurantApp.Infrastructure.Authentication
{
    public class PasswordHasherSettings
    {
        public int KeySize { get; set; }
        public int Iterations { get; set; }
        public string Algorithm { get; set; }
    }
}
