using Divstack.Company.Estimation.Tool.Inquiries.Application;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Mediation;

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
