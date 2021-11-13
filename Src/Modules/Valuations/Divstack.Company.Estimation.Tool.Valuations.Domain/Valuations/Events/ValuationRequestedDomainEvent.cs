namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;

using System;
using Deadlines;
using Shared.DDD.BuildingBlocks;

public sealed class ValuationRequestedDomainEvent : DomainEventBase
{
    public ValuationRequestedDomainEvent(
        ValuationId valuationId,
        InquiryId inquiryId,
        Deadline deadline)
    {
        ValuationId = valuationId;
        DeadlineDate = deadline.Date;
        InquiryId = inquiryId;
    }

    public ValuationId ValuationId { get; }
    public InquiryId InquiryId { get; }
    public DateTime DeadlineDate { get; }
}
