namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;

using System.Collections.Generic;

public record ValuationProposalsVm(IReadOnlyCollection<ValuationProposalEntryDto> Proposals);
