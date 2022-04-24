namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Subscribe.Inquiries;

using Microsoft.Extensions.DependencyInjection;

internal static class InquirySubscribersExtensions
{
    internal static void Subscribe<TEvent>(this IServiceCollection services) where TEvent : class
    {
        services.AddHostedService<InquiryEventSubscriber<TEvent>>();
    }
}
