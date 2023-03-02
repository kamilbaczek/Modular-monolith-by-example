namespace Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Commands.Archive;

using FluentValidation;

public sealed class ArchivePriorityCommandValidator : AbstractValidator<ArchivePriorityCommand>
{
    public ArchivePriorityCommandValidator()
    {
        RuleFor(command => command.ValuationId).NotEmpty();
    }
}
