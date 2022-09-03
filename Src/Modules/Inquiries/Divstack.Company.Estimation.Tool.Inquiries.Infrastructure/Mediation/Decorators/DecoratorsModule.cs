namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Mediation.Decorators;

using Logging;

internal static class DecoratorsModule
{
    internal static IServiceCollection AddDecorators(this IServiceCollection services)
    {
        services.AddLoggingDecorator();

        return services;
    }
}
