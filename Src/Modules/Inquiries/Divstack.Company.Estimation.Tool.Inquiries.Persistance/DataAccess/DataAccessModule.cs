namespace Divstack.Company.Estimation.Tool.Inquiries.Persistance.DataAccess;

using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

internal static class DataAccessModule
{
    internal static IServiceCollection AddDataAccess(this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<InquiriesContext>(connectionString);
        services.AddScoped<IDatabaseConnectionFactory, DatabaseConnectionFactory>();

        return services;
    }

    private static void AddDbContext<TContext>(this IServiceCollection services, string connectionString)
        where TContext : DbContext
    {
        services.AddDbContextPool<TContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
        );

        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<TContext>();
        // dbContext.Database.Migrate();
    }
}
