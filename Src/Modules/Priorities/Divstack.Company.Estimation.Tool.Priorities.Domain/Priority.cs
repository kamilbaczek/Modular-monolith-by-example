namespace Divstack.Company.Estimation.Tool.Priorities.Domain;

using Deadlines;
using Events;
using Policies;
using Shared.DDD.BuildingBlocks;

public sealed class Priority : Entity
{
    public PriorityId Id { get; init; }
    private ValuationId ValuationId { get; init; }
    private IList<ClientLoseRisk> Scores { get; init; }
    internal PriorityLevel Level { get; private set; }
    private Deadline? Deadline { get; init; }
    private PriorityLevel? ManualSetLevel { get; set; }

    private Priority(ValuationId valuationId, int? companySize, Deadline? deadline)
    {
        Id = PriorityId.Create();
        ValuationId = valuationId;
        Deadline = deadline;
        ManualSetLevel = null;
        Scores = new List<ClientLoseRisk>();
        Level = ManualSetLevel ?? Calculate(companySize);

        var @event = new PriorityDefinedDomainEvent(valuationId, Id);
        AddDomainEvent(@event);
    }

    public static Priority Define(ValuationId valuationId, int? companySize, Deadline? deadline)
    {
        return new Priority(valuationId, companySize, deadline);
    }

    public void Redefine(int? companySize)
    {
        Level = ManualSetLevel ?? Calculate(companySize);
    }
    internal void Force(PriorityLevel? priorityLevel)
    {
        ManualSetLevel = priorityLevel;
    }

    private PriorityLevel Calculate(int? companySize)
    {
        var largeCompanyPolicy = new IsLargeCompanyPolicy();
        var companyLarge = largeCompanyPolicy.IsLargeCompany(companySize);
        if (companyLarge)
            Increse(ClientLoseRisk.LargeClientCompany);
        if (Deadline!.Exceeded)
            Increse(ClientLoseRisk.DeadlineExceed);
        if (!Deadline!.Exceeded)
        {
            var closeToDeadline = ClientLoseRisk.CloseToDeadline(Deadline.DaysToDeadline);
            if(closeToDeadline.Scores > 0)
                Increse(closeToDeadline);
        }

        return PriorityLevel.Calculate(Scores.ToList());
    }

    private void Increse(ClientLoseRisk clientLoseRisk)
    {
        Scores.Add(clientLoseRisk);
    }
}
