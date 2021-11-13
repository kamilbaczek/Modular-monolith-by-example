namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

using System;
using Proposals;

public sealed class ProposalAlreadyCancelledException : InvalidOperationException
{
    public ProposalAlreadyCancelledException(ProposalId proposalId) : base(
        $"Proposal: {proposalId} already is cancelled.")
    {
    }
}
