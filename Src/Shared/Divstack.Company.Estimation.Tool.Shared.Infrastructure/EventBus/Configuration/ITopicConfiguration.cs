namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Configuration;

public interface ITopicConfiguration
{
    string TopicName { get; }
    string SubscriptionName { get; }
}
