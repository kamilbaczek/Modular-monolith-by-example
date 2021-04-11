using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.SuggestProposal
{
    public sealed class SuggestProposalCommandValidator : AbstractValidator<SuggestProposalCommand>
    {
        public SuggestProposalCommandValidator()
        {
            RuleFor(command => command.Currency).NotEmpty();
            RuleFor(command => command.Description).NotEmpty().MaximumLength(255);
            RuleFor(command => command.valuationId).NotEmpty();
            RuleFor(command => command.Value).GreaterThanOrEqualTo(0);
        }
    }
}
