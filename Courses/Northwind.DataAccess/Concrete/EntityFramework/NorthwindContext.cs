using Microsoft.EntityFrameworkCore;
using Northwind.Entities.Concrete;

namespace Northwind.DataAccess.Concrete;

public class NorthwindContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Northwind;Username=postgres;Password=test");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Category>().ToTable("categories");
    }
}