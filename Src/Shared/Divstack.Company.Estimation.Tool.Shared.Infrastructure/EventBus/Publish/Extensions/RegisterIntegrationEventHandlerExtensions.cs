namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Publish.Extensions;

using Subscribe;

public static class RegisterIntegrationEventHandlerExtensions
{
    public static void AddIntegrationEventsHandlers(this IServiceCollection services, Type type)
    {
        services.Scan(scan =>
            scan.FromAssembliesOf(type)
                .AddClasses(classes => classes.AssignableTo(typeof(IIntegrationEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
    }
}
