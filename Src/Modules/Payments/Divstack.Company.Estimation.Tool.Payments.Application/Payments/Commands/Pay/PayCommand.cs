namespace Divstack.Company.Estimation.Tool.Payments.Application.Payments.Commands.Pay;

using Common.Contracts;

public sealed class PayCommand : ICommand
{
    public Guid PaymentId { get; set; }
    public string Name { get; set; }
    public string CardNumber { get; set; }
    public long ExpYear { get; set; }
    public long ExpMonth { get; set; }

    public string Security { get; set; }
}
