namespace Divstack.Company.Estimation.Tool.Services.DataAccess;

using Core.Services;
using Core.Services.Categories;
using Microsoft.EntityFrameworkCore;
using Services;

public sealed class ServicesContext : DbContext
{
    public ServicesContext(DbContextOptions<ServicesContext> options)
        : base(options)
    {
    }

    internal DbSet<Service> Services { get; set; }
    internal DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ServiceEntityTypeConfiguration).Assembly);
    }
}
