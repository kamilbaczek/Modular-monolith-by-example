using Divstack.Company.Estimation.Tool.Valuations.Application;
using Divstack.Company.Estimation.Tool.Valuations.Persistance;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Mediation
{
    internal static class MediationModule
    {
        internal static IServiceCollection AddMediationModule(this IServiceCollection services)
        {
            var commandsHandlersAssembly = typeof(ApplicationModule).Assembly;
            var queryHandlersAssembly = typeof(PersistanceModule).Assembly;
            var cqsAssemblies = new[] {commandsHandlersAssembly, queryHandlersAssembly};

            services.AddMediatR(cqsAssemblies);
            services.AddFluentValidation(cqsAssemblies);

            return services;
        }
    }
}