#pragma warning disable CS8618
namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;

public sealed class ValuationHistoryDto
{
    public ValuationHistoryDto()
    {
    }

    public ValuationHistoryDto(Guid id)
    {
        Id = id;
        History = new List<ValuationHistoricalEntryDto>();
    }
    public Guid Id { get; set; }
    public IList<ValuationHistoricalEntryDto> History { get; set; }

    public void AddEntry(ValuationHistoricalEntryDto historyDto)
    {
        History.Add(historyDto);
    }
}
