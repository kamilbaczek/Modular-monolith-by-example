using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender
{
    internal record ValuationProposalSuggestedEmailRequest(
        string FullName,
        string ClientEmail,
        Guid ValuationId,
        Guid ProposalId,
        Money Value,
        string Description);
}