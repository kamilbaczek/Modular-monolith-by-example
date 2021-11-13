namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Charge;

using Common.Contracts;

public sealed class ChargeCommand : ICommand
{
    public Guid PaymentId { get; set; }
}
