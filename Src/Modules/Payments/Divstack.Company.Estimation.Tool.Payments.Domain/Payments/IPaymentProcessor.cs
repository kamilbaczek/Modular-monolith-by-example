namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

public record Card(    string       Number,
    int ExpMonth,
    int ExpYear,
    string Cvc)
{
    
}
public interface IPaymentProcessor
{
    void Pay(PaymentSecret paymentSecret, string name,
        string cardNumber,
        long expMonth,
        long expYear, 
        string security );
    PaymentSecret Initialize(Money amountToPay);
}
