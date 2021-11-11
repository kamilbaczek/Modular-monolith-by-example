using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;

public record ValuationListVm(IReadOnlyCollection<ValuationListItemDto> Valuations)
{
    public long Count => Valuations.Count;
}
