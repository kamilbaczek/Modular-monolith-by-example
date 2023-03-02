namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Mediation;

using Application;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
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
        services.AddFluentValidation(cqsAssemblies);

        return services;
    }
}
