namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe.Extensions;

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using global::Azure.Messaging.ServiceBus;

internal static class ServiceBusReceivedMessageExtensions
{
    internal static async Task<TEvent> DeserializeMessageAsync<TEvent>(this ServiceBusReceivedMessage message, CancellationToken cancellationToken = default)
    {
        var body = message.Body.ToStream();
        var @event = await JsonSerializer.DeserializeAsync<TEvent>(body, cancellationToken: cancellationToken);

        return @event;
    }
}
