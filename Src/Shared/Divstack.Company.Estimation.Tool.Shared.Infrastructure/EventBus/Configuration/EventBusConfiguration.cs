namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Configuration;

internal sealed class EventBusConfiguration : IEventBusConfiguration
{
    private const string EventBus = "EventBus";
    private readonly IConfiguration _configuration;

    public EventBusConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string ConnectionString => _configuration.GetValue<string>($"{EventBus}:{nameof(ConnectionString)}");
}
