using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll
{
    public record ValuationListVm(IEnumerable<ValuationListItemDto> Valuations);
}