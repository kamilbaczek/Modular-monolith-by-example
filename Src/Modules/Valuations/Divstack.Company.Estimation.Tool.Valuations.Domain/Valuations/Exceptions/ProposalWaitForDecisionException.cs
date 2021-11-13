namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

using System;
using Proposals;

public sealed class ProposalWaitForDecisionException : InvalidOperationException
{
    public ProposalWaitForDecisionException(ProposalId proposalId) :
        base(
            "Cannot execute operation if any proposal wait for decision. " +
            $"Proposal: {proposalId} wait for decision." +
            "Wait for decision or cancel proposal to ")
    {
    }
}
