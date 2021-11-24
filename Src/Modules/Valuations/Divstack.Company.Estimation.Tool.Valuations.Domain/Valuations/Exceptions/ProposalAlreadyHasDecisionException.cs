namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

using Proposals;

public sealed class ProposalAlreadyHasDecisionException : InvalidOperationException
{
    public ProposalAlreadyHasDecisionException(ProposalId proposalId) :
        base($"Proposal: {proposalId} already has decision.")
    {
    }
}
