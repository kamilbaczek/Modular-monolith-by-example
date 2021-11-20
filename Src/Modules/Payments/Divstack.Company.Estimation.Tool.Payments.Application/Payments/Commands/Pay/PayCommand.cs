namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay;

using Common.Contracts;

public sealed class PayCommand : ICommand
{
    public Guid PaymentId { get; set; }
    public string CardNumber { get; set; }
    public int ExpYear { get; set; }
    public int ExpMonth { get; set; }
    public string Cvc { get; set; }
}
