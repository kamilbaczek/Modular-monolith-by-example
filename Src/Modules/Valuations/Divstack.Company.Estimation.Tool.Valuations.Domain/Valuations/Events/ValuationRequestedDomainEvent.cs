using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;

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
