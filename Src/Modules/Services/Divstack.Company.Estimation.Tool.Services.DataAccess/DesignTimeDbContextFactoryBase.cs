namespace Divstack.Company.Estimation.Tool.Services.DataAccess;

using System;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

internal abstract class DesignTimeDbContextFactoryBase<TContext> :
    IDesignTimeDbContextFactory<TContext> where TContext : DbContext
{
    private const string ConnectionStringName = "Services";
    private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

    public TContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory() +
                       string.Format("{0}..{0}Divstack.Company.Estimation.Tool.Bootstrapper",
                           Path.DirectorySeparatorChar);
        return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
    }

    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

    private TContext Create(string basePath, string environmentName)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json", true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString(ConnectionStringName);

        return Create(connectionString);
    }

    private TContext Create(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.",
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
