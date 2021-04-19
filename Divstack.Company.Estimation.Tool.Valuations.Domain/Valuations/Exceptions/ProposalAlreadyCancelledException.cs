using System;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Exceptions
{
    public sealed class ProposalAlreadyCancelledException : InvalidOperationException
    {
        public ProposalAlreadyCancelledException(ProposalId proposalId) : base(
            $"Proposal: {proposalId} already is cancelled.")
        {
        }
    }
}