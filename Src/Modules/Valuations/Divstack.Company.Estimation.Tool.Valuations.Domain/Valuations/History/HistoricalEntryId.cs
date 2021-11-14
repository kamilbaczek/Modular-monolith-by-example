namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.History;

using System;

public record HistoricalEntryId(Guid Value)
{
    public static HistoricalEntryId Create() => new(Guid.NewGuid());
}
