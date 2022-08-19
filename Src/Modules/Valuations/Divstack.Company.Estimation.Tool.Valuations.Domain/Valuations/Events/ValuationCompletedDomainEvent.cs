namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Events;

public sealed class ValuationCompletedDomainEvent : DomainEventBase
{
    public ValuationCompletedDomainEvent(InquiryId inquiryId, ValuationId valuationId, EmployeeId employeeId, Money price)
    {
        InquiryId = inquiryId;
        ValuationId = valuationId;
        EmployeeId = employeeId;
        Price = price;
    }

    public InquiryId InquiryId { get; }
    public ValuationId ValuationId { get; }
    public EmployeeId EmployeeId { get; }
    public Money Price { get; }
}
