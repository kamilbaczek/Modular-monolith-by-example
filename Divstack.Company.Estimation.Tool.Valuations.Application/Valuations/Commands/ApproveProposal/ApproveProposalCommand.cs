using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal
{
    public sealed class ApproveProposalCommand : ICommand
    {
        public Guid ProposalId { get; set; }
        public Guid ValuationId { get; set; }
    }
}
