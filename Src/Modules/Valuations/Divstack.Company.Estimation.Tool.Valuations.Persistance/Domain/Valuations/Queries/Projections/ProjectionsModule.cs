namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Projections;

using Handlers.Get;
using Handlers.GetAll;
using Handlers.GetHistory;
using Handlers.GetProposals;
using Marten;
using Marten.Events.Projections;
using Microsoft.Extensions.DependencyInjection;
using Weasel.Core;

internal static class ProjectionsModule
{
    internal static IServiceCollection AddProjections(this IServiceCollection services, string connectionString)
    {
        services.AddMarten(options =>
            {
                options.Connection(connectionString);
                options.Projections.Add<ProposalsAggregation>(ProjectionLifecycle.Async);
                options.Projections.Add<HistoryAggregation>(ProjectionLifecycle.Async);
                options.Projections.Add<ValuationInformationAggregation>(ProjectionLifecycle.Async);
                options.Projections.Add<ValuationListItemAggregation>(ProjectionLifecycle.Async);

                options.AutoCreateSchemaObjects = AutoCreate.All;
            }
        );

        return services;
    }
}
