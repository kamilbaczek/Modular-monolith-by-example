using System;
using Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Proposals;

namespace Divstack.Company.Estimation.Tool.Estimations.Domain.Valuations.Exceptions
{
    public sealed class ProposalNotFoundException : InvalidOperationException
    {
        public ProposalNotFoundException(ProposalId proposalId) :
            base($"Proposal: {proposalId} not found.")
        {
        }
    }
}