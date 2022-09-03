namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Mediation.Decorators.Logging;

using MediatR;
using Microsoft.Extensions.DependencyInjection;

internal static class LoggingModule
{
    internal static IServiceCollection AddLoggingDecorator(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingDecorator<,>));

        return services;
    }
}
