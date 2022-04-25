namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Configuration;

using Microsoft.Extensions.Configuration;

internal sealed class EventBusConfiguration : IEventBusConfiguration
{
    private readonly IConfiguration _configuration;
    public EventBusConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string ConnectionString => _configuration.GetValue<string>("EventBus:ConnectionString");
}
