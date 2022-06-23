using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Services.Api")]

namespace Divstack.Company.Estimation.Tool.Services.DataAccess;

using System;
using Core;
using HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Seeder;
using Services;

internal static class DataAccessModule
{
    private const string ServicesConnectionString = "Services";

    internal static IServiceCollection AddDataAccess(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ServicesConnectionString);

        services.AddCore();
        services.RegisterRepositories();
        services.AddSeeders();
        services.AddDataAccessHealthChecks(connectionString);
        services.AddDbContext<ServicesContext>(connectionString);

        return services;
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblyOf<ServicesRepository>()
            .AddClasses(filter => filter.Where(@class => @class.Name.EndsWith("Repository", StringComparison.InvariantCultureIgnoreCase)))
            .AsImplementedInterfaces()
            .WithTransientLifetime());
    }

    private static void AddDbContext<TContext>(this IServiceCollection services, string connectionString)
        where TContext : DbContext
    {
        services.AddDbContextPool<TContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );

        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();
        dbContext.Database.Migrate();
    }
}
