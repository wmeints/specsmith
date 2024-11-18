using Microsoft.EntityFrameworkCore;

using SpecSmith.Models;

namespace SpecSmith.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Feature> Features => Set<Feature>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>().Property<byte[]>("Version").IsRowVersion();
        modelBuilder.Entity<Feature>().Property<byte[]>("Version").IsRowVersion();

        modelBuilder.Entity<Project>().HasMany(x => x.Features).WithOne(x => x.Project);
    }
}