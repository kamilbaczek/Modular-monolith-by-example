namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Charge;

using FluentValidation;

public sealed class ChargeCommandValidator : AbstractValidator<ChargeCommand>
{
    public ChargeCommandValidator()
    {
        RuleFor(command => command.PaymentId).NotEmpty();
    }
}
