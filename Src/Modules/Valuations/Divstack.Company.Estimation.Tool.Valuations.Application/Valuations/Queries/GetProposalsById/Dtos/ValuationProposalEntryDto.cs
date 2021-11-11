using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos;

public record ValuationProposalEntryDto(
    Guid ProposalId,
    string Message,
    string Currency,
    decimal Value,
    DateTime? Suggested,
    Guid? SuggestedBy,
    DateTime? DecisionDate,
    string Decision);
