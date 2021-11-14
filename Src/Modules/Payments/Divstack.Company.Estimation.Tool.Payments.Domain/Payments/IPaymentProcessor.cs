namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public record Card(    string       Number,
    int ExpMonth,
    int ExpYear,
    string Cvc)
{
    
}
public interface IPaymentProcessor
{
    void Pay(PaymentSecret paymentSecret, string token);
    PaymentSecret Initialize(Money amountToPay);
}
