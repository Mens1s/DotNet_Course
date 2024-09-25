using Microsoft.EntityFrameworkCore;
using RecapProject1.Entities;

namespace RecapProject1;

public class NorthwindContext:DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Categories> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Northwind;Username=postgres;Password=test");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<Categories>().ToTable("categories");
    }
}