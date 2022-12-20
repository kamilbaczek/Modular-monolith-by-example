namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.States;

using Events;

public sealed class ValuationCompleted : Entity, IAggregateRoot, IValuationState
{
    private ValuationCompleted() { }

    private ValuationCompleted(
        InquiryId inquiryId,
        EmployeeId employeeId,
        Money money)
    {
        var @event = new ValuationCompletedDomainEvent(InquiryId, ValuationId, employeeId, money);
        Apply(@event);
        AddDomainEvent(@event);
    }

    public Guid Id { get; set; }
    private InquiryId InquiryId { get; set; }
    private DateTime? CompletedDate { get; set; }
    private EmployeeId CompletedBy { get; set; }
    public ValuationId ValuationId => ValuationId.Of(Id);

    internal static ValuationCompleted Create(InquiryId inquiryId, EmployeeId employeeId, Money money) => 
        new(inquiryId, employeeId, money);

    private void Apply(ValuationCompletedDomainEvent @event)
    {
        CompletedBy = @event.EmployeeId;
        CompletedDate = @event.OccurredOn;
    }

    private void Apply(ValuationRequestedDomainEvent @event)
    {
        Id = @event.ValuationId.Value;
        InquiryId = @event.InquiryId;
    }

    internal void When(object @event)
    {
        switch (@event)
        {
            case ValuationRequestedDomainEvent valuationRequestedDomainEvent:
                Apply(valuationRequestedDomainEvent);
                break;
            case ValuationCompletedDomainEvent valuationCompletedDomainEvent:
                Apply(valuationCompletedDomainEvent);
                break;
        }
    }
}
