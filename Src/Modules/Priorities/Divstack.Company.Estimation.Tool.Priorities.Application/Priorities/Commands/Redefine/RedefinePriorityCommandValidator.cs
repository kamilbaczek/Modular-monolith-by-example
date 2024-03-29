﻿namespace Divstack.Company.Estimation.Tool.Priorities.Application.Priorities.Commands.Redefine;

using FluentValidation;

public sealed class RedefinePriorityCommandValidator : AbstractValidator<RedefinePriorityCommand>
{
    public RedefinePriorityCommandValidator()
    {
        RuleFor(command => command.ValuationId).NotEmpty();
        RuleFor(command => command.InquiryId).NotEmpty();
    }
}
