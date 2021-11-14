namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay;

using FluentValidation;

public sealed class PayCommandValidator : AbstractValidator<PayCommand>
{
    public PayCommandValidator()
    {
        RuleFor(command => command.PaymentId).NotEmpty();
    }
}
