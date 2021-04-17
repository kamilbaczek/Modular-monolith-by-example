using System;
using Divstack.Company.Estimation.Tool.Estimations.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.CancelProposal
{
    public sealed class CancelProposalCommand : ICommand
    {
        public Guid ProposalId { get; set; }
        public Guid ValuationId { get; set; }
    }
}
