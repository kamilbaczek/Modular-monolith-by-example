namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.RedefinePriority;

using FluentValidation;

public sealed class RedefinePriorityCommandValidator : AbstractValidator<RedefinePriorityCommand>
{
    public RedefinePriorityCommandValidator()
    {
        RuleFor(command => command.ValuationId).NotEmpty();
        RuleFor(command => command.InquiryId).NotEmpty();
    }
}
