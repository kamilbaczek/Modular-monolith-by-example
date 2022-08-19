namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;

public record struct ValuationProposalsVm(IReadOnlyCollection<ValuationProposalEntryDto> Proposals);
