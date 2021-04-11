using System;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions
{
    public sealed class ProposalAlreadyCancelledException : InvalidOperationException
    {
        public ProposalAlreadyCancelledException(ProposalId proposalId) : base($"Proposal: {proposalId} already is cancelled.")
        {
        }
    }
}
