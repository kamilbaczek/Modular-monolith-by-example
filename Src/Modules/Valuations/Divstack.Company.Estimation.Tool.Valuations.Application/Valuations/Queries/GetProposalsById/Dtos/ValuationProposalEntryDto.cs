namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;

public record ValuationProposalEntryDto(Guid Id,
    Guid ProposalId,
    string Message,
    string Currency,
    decimal Value,
    DateTime? Suggested,
    Guid? SuggestedBy,
    DateTime? DecisionDate,
    string Decision);
