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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Add sample data that is inserted when performing migration.
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Thriller", DisplayOrder = 1},
            new Category { Id = 2, Name = "Horror", DisplayOrder = 2},
            new Category { Id = 3, Name = "Science Fiction", DisplayOrder = 3}
        );
    }
}