using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Proposals.Exceptions
{
    public sealed class ProposalIsCancelledException : InvalidOperationException
    {
        public ProposalIsCancelledException(ProposalId proposalId) : base($"Proposal: {proposalId} is cancelled." +
                                                                          $" You can't execute any operations on that proposal")
        {
        }
    }
}
