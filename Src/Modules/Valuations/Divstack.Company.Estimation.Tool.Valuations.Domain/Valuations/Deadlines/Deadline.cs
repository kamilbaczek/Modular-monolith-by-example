namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;

using Shared.DDD.BuildingBlocks;

public sealed class Deadline : ValueObject
{
    private Deadline(int daysToDeadlineFromNow)
    {
        Date = SystemTime.Now().AddDays(daysToDeadlineFromNow);
    }

    internal DateTime Date { get; init; }

    public static Deadline Create(IDeadlinesConfiguration deadlinesConfiguration)
    {
        return new Deadline(deadlinesConfiguration.WorksDaysToDeadlineFromNow);
    }
}
