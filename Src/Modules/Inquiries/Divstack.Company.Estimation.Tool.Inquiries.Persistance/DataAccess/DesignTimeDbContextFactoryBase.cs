namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.DataAccess;

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

internal abstract class DesignTimeDbContextFactoryBase<TContext> :
    IDesignTimeDbContextFactory<TContext> where TContext : DbContext
{
    public TContext CreateDbContext(string[] args)
    {
        return Create();
    }

    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

    private TContext Create()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<InquiriesContext>()
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString(DataAccessConstants.ConnectionStringName);

        return Create(connectionString);
    }

    private TContext Create(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException(
                $"Connection string '{DataAccessConstants.ConnectionStringName}' is null or empty.",
                nameof(connectionString));
        }
        var optionsBuilder = new DbContextOptionsBuilder<TContext>();

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
            dbContextOptionsBuilder =>
            {
                dbContextOptionsBuilder.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name);
            });

        return CreateNewInstance(optionsBuilder.Options);
    }
}
