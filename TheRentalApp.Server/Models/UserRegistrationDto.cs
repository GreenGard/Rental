namespace TheRentalApp.Server.Models
{
    public class UserRegistrationDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<string> Roles { get; set; } = new List<string>(); 
    }
}
