using Microsoft.AspNetCore.Mvc;
using TheRentalApp.Server.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TheRentalApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserController(ApplicationDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        // Test database connection
        [HttpGet("test-connection")]
        public IActionResult TestConnection()
        {
            try
            {
                _context.Database.CanConnect();
                return Ok("Database connection is successful.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Database connection failed: {ex.Message}");
            }
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Create(UserRegistrationDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest("User data is null.");
            }

            if (string.IsNullOrEmpty(userDto.Username) || string.IsNullOrEmpty(userDto.Password))
            {
                return BadRequest("Username and password cannot be empty.");
            }

            
            var user = new User
            {
                Username = userDto.Username
            };

          
            user.PasswordHash = _passwordHasher.HashPassword(user, userDto.Password);


            try
            {
                _context.Users.Add(user);  
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error registering user: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }


        // GET: api/User/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            return Ok(user);
        }

        // PUT: api/User/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                // Update user details and hash password if changed
                user.Username = updatedUser.Username;
                user.PasswordHash = _passwordHasher.HashPassword(user, updatedUser.PasswordHash);

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error updating user: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Error deleting user: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Unexpected error: {ex.Message}");
            }
        }
    }
}
