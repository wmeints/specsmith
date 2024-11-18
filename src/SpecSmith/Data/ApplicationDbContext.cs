using Microsoft.EntityFrameworkCore;

using SpecSmith.Models;

namespace SpecSmith.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Feature> Features => Set<Feature>();
    public DbSet<Scenario> Scenarios => Set<Scenario>();
    public DbSet<Step> Steps => Set<Step>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Project>().Property<byte[]>("Version").IsRowVersion();
        modelBuilder.Entity<Feature>().Property<byte[]>("Version").IsRowVersion();
        modelBuilder.Entity<Scenario>().Property<byte[]>("Version").IsRowVersion();
        modelBuilder.Entity<Step>().Property<byte[]>("Version").IsRowVersion();

        modelBuilder.Entity<Project>().HasMany(x => x.Features).WithOne(x => x.Project);
        modelBuilder.Entity<Feature>().HasMany(x => x.Scenarios).WithOne(x => x.Feature);
        modelBuilder.Entity<Scenario>().HasMany(x => x.Steps).WithOne(x => x.Scenario);
    }
}