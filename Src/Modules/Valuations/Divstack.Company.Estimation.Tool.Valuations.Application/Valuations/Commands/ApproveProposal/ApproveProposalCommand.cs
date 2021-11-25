namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal;

using Common.Contracts;

public sealed class ApproveProposalCommand : ICommand
{
    public Guid ProposalId { get; set; }
    public Guid ValuationId { get; set; }
}
