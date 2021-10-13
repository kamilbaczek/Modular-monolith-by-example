using System;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender
{
    internal record ValuationProposalSuggestedEmailRequest(
        Guid ValuationId,
        Guid ProposalId,
        Guid InquiryId,
        decimal? Value,
        string Currency,
        string Description);
}