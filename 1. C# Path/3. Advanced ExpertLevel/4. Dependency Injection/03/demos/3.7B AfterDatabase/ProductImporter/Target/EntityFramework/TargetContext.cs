using Microsoft.EntityFrameworkCore;
using ProductImporter.Model;

namespace ProductImporter.Target.EntityFramework;

public class TargetContext : DbContext
{
    public TargetContext(DbContextOptions<TargetContext> options)
        : base(options)
    { }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Product>()
               .OwnsOne(p => p.Price);
    }
}
