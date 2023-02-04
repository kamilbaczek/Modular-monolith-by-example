namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Queries.Projections;

using Handlers.Get;
using Handlers.GetAll;
using Handlers.GetHistory;
using Handlers.GetProposals;
using Marten.Events.Projections;
using Microsoft.Extensions.DependencyInjection;
using Weasel.Core;

internal static class ProjectionsModule
{
    internal static IServiceCollection AddProjections(this IServiceCollection services, string connectionString)
    {
        services.AddMarten(options =>
        {
            options.UseDefaultSerialization(nonPublicMembersStorage: NonPublicMembersStorage.NonPublicSetters);
            options.Connection(connectionString);
            options.RetryPolicy();

            options.Projections.Add<ProposalsAggregation>(ProjectionLifecycle.Inline);
            options.Projections.Add<HistoryAggregation>(ProjectionLifecycle.Inline);
            options.Projections.Add<ValuationInformationAggregation>(ProjectionLifecycle.Inline);
            options.Projections.Add<ValuationListItemAggregation>(ProjectionLifecycle.Inline);

            options.AutoCreateSchemaObjects = AutoCreate.All;
        });

        return services;
    }
}
