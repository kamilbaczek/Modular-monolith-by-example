namespace Divstack.Company.Estimation.Tool.Valuations.IntegrationsEvents.ExternalEvents;

using System.Text.Json;
using Shared.DDD.BuildingBlocks;

public record ValuationCompleted(
    Guid InquiryId,
    Guid ValuationId,
    decimal? AmountToPayValue,
    string AmountToPayCurrency) : IntegrationEvent
{
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
