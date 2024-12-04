namespace TheRentalApp.Server.Models
{
    public class UserRegistrationDto
    {
   
        public required string Username { get; set; }
        public required string Password { get; set; }
      //  public List<string> Roles { get; set; } = new List<string>(); 
    }
}
