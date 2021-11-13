namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Sender;

using System;

internal record ValuationProposalApprovedEmailRequest(
    string SuggestedByEmployeeEmail,
    Guid ValuationId,
    Guid ProposalId,
    string Currency,
    decimal? Value);
