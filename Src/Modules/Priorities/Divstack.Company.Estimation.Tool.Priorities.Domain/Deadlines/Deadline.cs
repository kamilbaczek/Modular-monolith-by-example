namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Deadlines;

using Shared.DDD.BuildingBlocks;

public sealed class Deadline : ValueObject
{
    private Deadline(int daysToDeadlineFromNow)
    {
        Date = SystemTime.Now().AddDays(daysToDeadlineFromNow);
    }

    internal DateTime Date { get; init; }
    internal bool Exceeded => SystemTime.Now() > Date;
    internal int DaysToDeadline => (SystemTime.Now() - Date).Days;

    public static Deadline Create(IDeadlinesConfiguration deadlinesConfiguration)
    {
        return new Deadline(deadlinesConfiguration.WorksDaysToDeadlineFromNow);
    }
}
