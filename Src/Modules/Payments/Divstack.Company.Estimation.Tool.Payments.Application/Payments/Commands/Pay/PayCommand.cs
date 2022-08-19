namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay;

using Common.Contracts;
using Dtos.CreditCard;

public sealed class PayCommand : ICommand
{
    public Guid PaymentId { get; init; }
    public CreditCardDto? Card { get; init; }
}
