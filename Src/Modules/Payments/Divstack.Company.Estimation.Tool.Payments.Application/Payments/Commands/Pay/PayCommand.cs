namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay;

using Common.Contracts;

public sealed class PayCommand : ICommand
{
    public Guid PaymentId { get; set; }
}
