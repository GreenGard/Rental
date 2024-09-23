using System.ComponentModel.DataAnnotations;

namespace TheRentalApp.Server.Models
{
    public class Login
    {
      
        // [EmailAddress]
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        
        
        //[Display(Name = "Remember Me")]
        //public bool RememberMe { get; set; }
    }
}
