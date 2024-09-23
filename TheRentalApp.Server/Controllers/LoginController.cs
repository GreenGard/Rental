using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheRentalApp.Server.Models;
using System.Threading.Tasks;

namespace TheRentalApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public LoginController(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Login loginModel)
        {
          
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == loginModel.Username);

           
          

            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginModel.Password) == PasswordVerificationResult.Failed)

                {
                    return Unauthorized("Invalid username or password.");
            }



            return Ok(new { Message = "Login successful!" });
        }
    }
}
