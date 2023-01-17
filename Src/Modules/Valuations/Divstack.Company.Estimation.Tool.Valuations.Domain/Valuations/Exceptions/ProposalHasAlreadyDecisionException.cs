namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions;

using Proposals;

public sealed class ProposalHasAlreadyDecisionException : InvalidOperationException
{
    private static string GetMessage(ProposalId valuationId) => $"Proposal {valuationId} has already decision.";

    public ProposalHasAlreadyDecisionException(ProposalId valuationId) : base(GetMessage(valuationId))
    {
    }
}
