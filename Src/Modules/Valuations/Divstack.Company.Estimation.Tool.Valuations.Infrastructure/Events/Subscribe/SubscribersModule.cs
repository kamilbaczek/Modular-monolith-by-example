namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Events.Subscribe;

using Inquiries;
using Microsoft.Extensions.DependencyInjection;
using Tool.Inquiries.IntegrationsEvents.External;

internal static class SubscribersModule
{
    internal static void AddSubscribers(this IServiceCollection services)
    {
        services.Subscribe<InquiryMadeEvent>();
    }
}
