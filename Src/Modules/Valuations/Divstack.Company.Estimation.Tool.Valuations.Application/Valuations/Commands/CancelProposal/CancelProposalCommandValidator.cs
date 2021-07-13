using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.CancelProposal
{
    public sealed class CancelProposalCommandValidator : AbstractValidator<CancelProposalCommand>
    {
        public CancelProposalCommandValidator()
        {
            RuleFor(command => command.ProposalId).NotEmpty();
            RuleFor(command => command.ValuationId).NotEmpty();
        }
    }
}