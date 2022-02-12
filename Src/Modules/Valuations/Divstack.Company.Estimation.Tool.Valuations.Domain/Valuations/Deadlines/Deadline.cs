namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;

public sealed class Deadline : ValueObject
{
    private Deadline(int daysToDeadlineFromNow)
    {
        Date = SystemTime.Now().AddDays(daysToDeadlineFromNow);
    }

    internal DateTime Date { get; init; }
    internal bool Exceeded => SystemTime.Now() > Date;
    internal int DaysToDeadline => (SystemTime.Now() - Date).Days;

    public static Deadline? Create(IDeadlinesConfiguration deadlinesConfiguration)
    {
        return new Deadline(deadlinesConfiguration.WorksDaysToDeadlineFromNow);
    }
}
