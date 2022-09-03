namespace Divstack.Company.Estimation.Tool.Users.Infrastructure.Mediation;

using Application;
using Decorators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

internal static class MediationModule
{
    internal static IServiceCollection AddMediationModule(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ApplicationModule).Assembly;
        services.AddMediatR(applicationAssembly);
        services.AddValidatorsFromAssembly(applicationAssembly);

        services.AddDecorators();

        return services;
    }
}
