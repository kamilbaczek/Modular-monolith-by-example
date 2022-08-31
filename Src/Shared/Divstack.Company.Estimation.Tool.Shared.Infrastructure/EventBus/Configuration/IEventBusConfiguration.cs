namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Configuration;

public interface IEventBusConfiguration
{
    string ConnectionString { get; }
    string StorageConnectionString { get; }
    string DatabaseName { get; }
}
