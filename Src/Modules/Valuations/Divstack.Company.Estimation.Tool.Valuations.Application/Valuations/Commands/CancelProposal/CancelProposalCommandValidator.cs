namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.CancelProposal;

using FluentValidation;

public sealed class CancelProposalCommandValidator : AbstractValidator<CancelProposalCommand>
{
    public CancelProposalCommandValidator()
    {
        RuleFor(command => command.ProposalId).NotEmpty();
        RuleFor(command => command.ValuationId).NotEmpty();
    }
}
