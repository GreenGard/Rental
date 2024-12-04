using System.ComponentModel.DataAnnotations;

namespace TheRentalApp.Server.Models
{
    public class Login
    {
      
        // [EmailAddress]
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }
        
        
        //[Display(Name = "Remember Me")]
        //public bool RememberMe { get; set; }
    }
}
