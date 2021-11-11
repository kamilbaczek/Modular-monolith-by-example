using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;

public sealed class ValuationCompletedDomainEvent : DomainEventBase
{
    public ValuationCompletedDomainEvent(InquiryId inquiryId, ValuationId valuationId, Money price)
    {
        InquiryId = inquiryId;
        ValuationId = valuationId;
        Price = price;
    }

    public InquiryId InquiryId { get; }
    public ValuationId ValuationId { get; }
    public Money Price { get; }
}
