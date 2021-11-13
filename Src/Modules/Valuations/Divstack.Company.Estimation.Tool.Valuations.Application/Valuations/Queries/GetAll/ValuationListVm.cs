namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;

using System.Collections.Generic;

public record ValuationListVm(IReadOnlyCollection<ValuationListItemDto> Valuations)
{
    public long Count => Valuations.Count;
}
