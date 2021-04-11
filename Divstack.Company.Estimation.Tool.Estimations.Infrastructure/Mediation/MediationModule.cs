using Divstack.Company.Estimation.Tool.Estimations.Application;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Mediation
{
    internal static class MediationModule
    {
        internal static IServiceCollection AddMediationModule(this IServiceCollection services)
        {
            var applicationAssembly = typeof(ApplicationModule).Assembly;
            services.AddMediatR(applicationAssembly);
            services.AddValidatorsFromAssembly(applicationAssembly);

            return services;
        }
    }
}
