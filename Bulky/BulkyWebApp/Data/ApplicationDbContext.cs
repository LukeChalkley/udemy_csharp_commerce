using BulkyWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWebApp.Data;

public class ApplicationDbContext : DbContext // DbContext is the root class of Entity Framework Core.
{
    // DbContextOptions will be passed in Program.cs using Dependency Injection.
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Category> Categories { get; set; }
}