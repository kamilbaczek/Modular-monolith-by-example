namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;

public record struct ValuationListVm(IReadOnlyCollection<ValuationListItemDto> Valuations)
{
    public long Count => Valuations.Count;
}
