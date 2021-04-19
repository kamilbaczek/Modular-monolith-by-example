using System;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions
{
    public sealed class ProposalAlreadyHasDecisionException : InvalidOperationException
    {
        public ProposalAlreadyHasDecisionException(ProposalId proposalId) :
            base($"Proposal: {proposalId} already has decision.")
        {
        }
    }
}