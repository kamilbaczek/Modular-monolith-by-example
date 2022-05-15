namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.EventBus.Subscribe.Extensions;

using global::Azure.Messaging.ServiceBus;
using JsonSerializer = System.Text.Json.JsonSerializer;

internal static class ServiceBusReceivedMessageExtensions
{
    internal static async Task<TEvent> DeserializeAsync<TEvent>(this ServiceBusReceivedMessage message, CancellationToken cancellationToken = default)
    {
        var body = message.Body.ToStream();
        var @event = await JsonSerializer.DeserializeAsync<TEvent>(body, cancellationToken: cancellationToken);

        return @event;
    }
}
