namespace Divstack.Company.Estimation.Tool.Payments.Infrastructure.Mediation;

using Application;
using MediatR;

internal static class MediationModule
{
    internal static IServiceCollection AddMediationModule(this IServiceCollection services)
    {
        var commandsHandlersAssembly = typeof(ApplicationModule).Assembly;
        // var queryHandlersAssembly = typeof(PersistanceModule).Assembly;
        var cqsAssemblies = new[]
        {
            commandsHandlersAssembly
        };

        services.AddMediatR(cqsAssemblies);

        return services;
    }
}
