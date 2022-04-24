namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal.Configuration;

using Infrastructure.Configuration;

internal sealed class InquiryTopicConfiguration : IInquiryTopicConfiguration
{
    public string? TopicName { get; }
    public string? SubscriptionName { get; }
}
