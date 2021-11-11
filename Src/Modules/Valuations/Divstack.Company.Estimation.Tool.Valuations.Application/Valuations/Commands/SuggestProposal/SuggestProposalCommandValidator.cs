using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;

public sealed class SuggestProposalCommandValidator : AbstractValidator<SuggestProposalCommand>
{
    public SuggestProposalCommandValidator()
    {
        RuleFor(command => command.Currency).NotEmpty();
        RuleFor(command => command.Description).NotEmpty().MaximumLength(255);
        RuleFor(command => command.ValuationId).NotEmpty();
        RuleFor(command => command.Value).GreaterThanOrEqualTo(0);
    }
}
