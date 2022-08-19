namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.CancelProposal;

using Common.Contracts;

public sealed class CancelProposalCommand : ICommand
{
    public Guid ProposalId { get; set; }
    public Guid ValuationId { get; set; }
}
