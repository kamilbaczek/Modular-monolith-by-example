using Divstack.Company.Estimation.Tool.Valuations.Application;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Mediation
{
    internal static class MediationModule
    {
        internal static IServiceCollection AddMediationModule(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ApplicationModule).Assembly;
            services.AddMediatR(applicationAssembly);
            services.AddFluentValidation(new[] {applicationAssembly});

            return services;
        }
    }
}