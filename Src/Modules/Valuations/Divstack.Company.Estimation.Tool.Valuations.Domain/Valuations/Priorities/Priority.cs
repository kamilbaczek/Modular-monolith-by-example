namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Priorities;

using Deadlines;
using Policies;

public sealed class Priority : ValueObject
{
    private IList<ClientLoseRisk> Scores { get; }
    internal PriorityLevel Level { get; }
    private Deadline? Deadline { get; }
    private PriorityLevel? ManualSetLevel { get; set; }

    internal Priority(int? companySize, Deadline? deadline)
    {
        Deadline = deadline;
        ManualSetLevel = null;
        Scores = new List<ClientLoseRisk>();
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
        if (companyLarge);
            Increse(ClientLoseRisk.LargeClientCompany);
        if (Deadline!.Exceeded)
            Increse(ClientLoseRisk.DeadlineExceed);

        var closeToDeadline = ClientLoseRisk.CloseToDeadline(Deadline.DaysToDeadline);
        if(closeToDeadline.Scores > 0)
            Increse(closeToDeadline);

        return PriorityLevel.Calculate(Scores.ToList());
    }

    private void Increse(ClientLoseRisk clientLoseRisk)
    {
        Scores.Add(clientLoseRisk);
    }

    public static bool operator >(Priority S1, Priority? S2)
    {
        return S1.Level > S2.Level;
    }

    public static bool operator <(Priority S1, Priority? S2)
    {
        return S1.Level < S2.Level;
    }
}
