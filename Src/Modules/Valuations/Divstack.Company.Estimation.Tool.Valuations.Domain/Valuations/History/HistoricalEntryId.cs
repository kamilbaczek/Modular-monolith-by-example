namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.History;

public record HistoricalEntryId(Guid Value)
{
    public static HistoricalEntryId Create()
    {
        return new(Guid.NewGuid());
    }
}
