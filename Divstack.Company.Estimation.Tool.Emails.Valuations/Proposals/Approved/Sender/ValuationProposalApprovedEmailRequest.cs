using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Sender
{
    internal record ValuationProposalApprovedEmailRequest(
        string SuggestedByEmployeeEmail,
        Guid ValuationId,
        Guid ProposalId,
        Money Value);
}