namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Mediation;

using Application;
using MediatR;
using Persistance;

internal static class MediationModule
{
    internal static IServiceCollection AddMediationModule(this IServiceCollection services)
    {
        var commandsHandlersAssembly = typeof(ApplicationModule).Assembly;
        var queryHandlersAssembly = typeof(PersistanceModule).Assembly;
        var cqsAssemblies = new[]
        {
            commandsHandlersAssembly, queryHandlersAssembly
        };

        services.AddMediatR(cqsAssemblies);

        return services;
    }
}
