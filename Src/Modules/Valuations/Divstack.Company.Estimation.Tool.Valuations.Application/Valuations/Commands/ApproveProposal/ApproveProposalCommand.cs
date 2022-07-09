namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal;

using Common.Contracts;

public record struct ApproveProposalCommand(Guid ProposalId, Guid ValuationId) : ICommand;
