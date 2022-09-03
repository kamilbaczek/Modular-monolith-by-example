namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Mediation;

using Application;
using Decorators;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;

internal static class MediationModule
{
    internal static IServiceCollection AddMediationModule(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ApplicationModule).Assembly;
        services.AddMediatR(applicationAssembly);
        services.AddFluentValidation(new[]
        {
            applicationAssembly
        });

        services.AddDecorators();

        return services;
    }
}
