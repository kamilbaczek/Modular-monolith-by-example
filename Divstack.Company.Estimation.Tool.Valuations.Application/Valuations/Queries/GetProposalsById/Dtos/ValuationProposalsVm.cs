using System;
using System.Collections.Generic;
using System.Linq;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos
{
    public record ValuationProposalsVm(IReadOnlyCollection<ValuationProposalEntryDto> Proposals)
    {
        public ValuationProposalsVm(IEnumerable<ValuationProposalEntryDto> valuationProposalEntryDtos) :
            this(valuationProposalEntryDtos.ToList().AsReadOnly())
        {
        }
    }
}
