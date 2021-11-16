namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

using Events;

public sealed class Payment : Entity, IAggregateRoot
{
    private Payment(ValuationId valuationId, InquiryId inquiryId, Money amountToPay, IPaymentProcessor paymentProcessor)
    {
        var paymentIntent = paymentProcessor.Initialize(amountToPay);
        PaymentSecret = Guard.Against.Null(paymentIntent, nameof(paymentIntent));
        ValuationId = Guard.Against.Null(valuationId, nameof(valuationId));
        Id = PaymentId.Create();
        AmountToPay = Guard.Against.Null(amountToPay, nameof(amountToPay));
        InquiryId = Guard.Against.Null(inquiryId, nameof(inquiryId));
        PaymentStatus = PaymentStatus.WaitForPayment;
        var @event = new PaymentInitializedDomainEvent(Id, ValuationId, InquiryId, AmountToPay);
       
        AddDomainEvent(@event);
    }

    public PaymentId Id { get; init; }
    private ValuationId ValuationId { get; init;}
    private InquiryId InquiryId { get; init;}
    private PaymentSecret PaymentSecret { get; init;}
    private PaymentStatus PaymentStatus { get; set; }
    private Money AmountToPay { get; init;}

    public static Payment Initialize(ValuationId valuationId, InquiryId inquiryId, Money amountToPay, IPaymentProcessor paymentProcessor)
    {
        return new Payment(valuationId, inquiryId, amountToPay, paymentProcessor);
    }

    public void Pay(
        IPaymentProcessor paymentProcessor, 
        string name,
        string cardNumber,
        long expMonth,
        long expYear, 
         string security )
    {
        paymentProcessor.Pay(PaymentSecret, name, cardNumber, expMonth, expYear,security);
        PaymentStatus = PaymentStatus.Payed;
    }
}
