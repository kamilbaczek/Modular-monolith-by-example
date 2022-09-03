namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Mediation.Decorators.Logging;

using MediatR;

internal static class LoggingModule
{
    internal static IServiceCollection AddLoggingDecorator(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingDecorator<,>));

        return services;
    }
}
