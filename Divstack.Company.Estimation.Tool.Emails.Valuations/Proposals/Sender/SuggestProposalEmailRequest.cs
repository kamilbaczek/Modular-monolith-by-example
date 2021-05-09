using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Sender
{
    internal record SuggestProposalEmailRequest(
        string FullName,
        string ClientEmail,
        Guid ValuationId,
        Guid ProposalId,
        Money Value,
        string Description);
}
