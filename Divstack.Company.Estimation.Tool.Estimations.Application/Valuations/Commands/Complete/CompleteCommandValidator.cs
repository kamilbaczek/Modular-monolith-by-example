using FluentValidation;

namespace Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.Complete
{
    public sealed class CompleteCommandValidator : AbstractValidator<CompleteCommand>
    {
        public CompleteCommandValidator()
        {
            RuleFor(command => command.ValuationId).NotEmpty();
        }
    }
}
