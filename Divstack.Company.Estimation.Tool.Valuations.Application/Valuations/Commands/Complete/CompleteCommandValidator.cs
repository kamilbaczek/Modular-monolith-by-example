using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Complete
{
    public sealed class CompleteCommandValidator : AbstractValidator<CompleteCommand>
    {
        public CompleteCommandValidator()
        {
            RuleFor(command => command.ValuationId).NotEmpty();
        }
    }
}
