using System.Collections.Generic;
using System.Linq;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos
{
    public record ValuationProposalsVm(IReadOnlyCollection<ValuationProposalEntryDto> Proposals);
}