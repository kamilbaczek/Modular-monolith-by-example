namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

using Deadlines;
using Events;
using Policies;
using Shared.DDD.BuildingBlocks;

public sealed class Priority : Entity
{
    private Priority(ValuationId valuationId, InquiryId inquiryId, int? companySize, Deadline deadline)
    {
        Id = PriorityId.Create();
        ValuationId = valuationId;
        Deadline = deadline;
        ManualSetLevel = null;
        InquiryId = inquiryId;
        Scores = new List<ClientLoseRisk>();
        Level = ManualSetLevel ?? Calculate(companySize);

        var @event = new PriorityDefinedDomainEvent(valuationId, Id, Deadline.Date);
        AddDomainEvent(@event);
    }
    public PriorityId Id { get; init; }
    public ValuationId ValuationId { get; init; }
    private InquiryId InquiryId { get; }
    private IList<ClientLoseRisk> Scores { get; }
    internal PriorityLevel Level { get; private set; }
    private Deadline Deadline { get; }
    private PriorityLevel? ManualSetLevel { get; set; }
    private bool Archived { get; set; }

    public static Priority Define(
        ValuationId valuationId,
        InquiryId inquiryId,
        int? companySize,
        Deadline deadline)
    {
        return new Priority(valuationId, inquiryId, companySize, deadline);
    }

    public void Redefine(int? companySize)
    {
        var oldLevel = Level;

        Level = ManualSetLevel ?? Calculate(companySize);

        if (oldLevel < Level)
        {
            var @event = new PriorityIncreasedDomainEvent(Id, Level);
            AddDomainEvent(@event);
        }
    }

    public void Archive()
    {
        Archived = true;
    }

    internal void Force(PriorityLevel? priorityLevel)
    {
        ManualSetLevel = priorityLevel;
    }

    private PriorityLevel Calculate(int? companySize)
    {
        Clear();
        var companyLarge = IsLargeCompanyPolicy.IsLargeCompany(companySize);
        if (companyLarge)
            Increse(ClientLoseRisk.LargeClientCompany);
        if (Deadline.Exceeded)
            Increse(ClientLoseRisk.DeadlineExceed);
        if (!Deadline.Exceeded)
        {
            var closeToDeadline = ClientLoseRisk.CloseToDeadline(Deadline.DaysToDeadline);
            if (closeToDeadline.Scores > 0)
                Increse(closeToDeadline);
        }

        return PriorityLevel.Calculate(Scores.ToList());
    }

    private void Increse(ClientLoseRisk clientLoseRisk)
    {
        Scores.Add(clientLoseRisk);
    }

    private void Clear()
    {
        Scores.Clear();
    }
}
