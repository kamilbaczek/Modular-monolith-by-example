namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay;

using FluentValidation;

public sealed class PayCommandValidator : AbstractValidator<PayCommand>
{
    public PayCommandValidator()
    {
        RuleFor(command => command.PaymentId).NotEmpty();
        RuleFor(command => command.Card!.CardNumber).NotEmpty();
        RuleFor(command => command.Card!.Cvc).NotEmpty();
        RuleFor(command => command.Card!.ExpMonth).NotEmpty();
        RuleFor(command => command.Card!.ExpYear).NotEmpty();
    }
}
