using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.BuildingBlocks;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;

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
