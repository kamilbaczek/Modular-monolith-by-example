using System;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Sender;

internal record ValuationProposalApprovedEmailRequest(
    string SuggestedByEmployeeEmail,
    Guid ValuationId,
    Guid ProposalId,
    string Currency,
    decimal? Value);
