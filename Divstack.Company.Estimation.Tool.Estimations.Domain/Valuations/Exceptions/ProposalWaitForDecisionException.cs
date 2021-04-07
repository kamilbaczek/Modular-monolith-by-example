using System;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions
{
    public sealed class ProposalWaitForDecisionException : InvalidOperationException
    {
        public ProposalWaitForDecisionException(ProposalId proposalId) :
            base(
            "Cannot execute operation if any proposal wait for decision. " +
            $"Proposal: {proposalId} wait for decision." +
            "Wait for decision or cancel proposal to ")
        {}
    }
}
