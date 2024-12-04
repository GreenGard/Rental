using Microsoft.EntityFrameworkCore;
using TheRentalApp.Server.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public object UserRoles { get; internal set; }
    public object Roles { get; internal set; }
}



