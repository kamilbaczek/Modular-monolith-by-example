namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus;

public interface ITopicConfiguration
{
    string TopicName { get; }
    string SubscriptionName { get; }
}
