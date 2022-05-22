namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Projections;

using Marten;
using Marten.Events.Daemon.Resiliency;
using Marten.Events.Projections;
using Microsoft.Extensions.DependencyInjection;
using Weasel.Core;

internal static class ProjectionsModule
{
    private const string ConnectionString =
         "PORT = 5432; HOST = localhost; TIMEOUT = 15; POOLING = True; DATABASE = 'postgres'; PASSWORD = 'Password12!'; USER ID = 'postgres'";

    internal static IServiceCollection AddProjections(this IServiceCollection services)
    {
        services.AddMartenStore<DocumentStore>(storeOptions =>
        {
            storeOptions.Projections.Add<ValuationInformationProjection>(ProjectionLifecycle.Async);
            storeOptions.Connection(ConnectionString);
            //TODO only on dev
            storeOptions.AutoCreateSchemaObjects = AutoCreate.All;

        })
        .AddAsyncDaemon(DaemonMode.Solo);

        return services;
    }
}
