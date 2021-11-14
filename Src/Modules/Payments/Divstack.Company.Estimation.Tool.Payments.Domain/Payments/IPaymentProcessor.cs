namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public interface IPaymentProcessor
{
    void Pay(PaymentSecret paymentSecret, PaymentMethod paymentMethod);
    PaymentSecret Initialize(Money amountToPay);
}
