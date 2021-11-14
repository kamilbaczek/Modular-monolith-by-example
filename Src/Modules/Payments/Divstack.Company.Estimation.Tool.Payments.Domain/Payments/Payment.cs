namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

using Events;

public sealed class Payment : Entity, IAggregateRoot
{
    private Payment(ValuationId valuationId, InquiryId inquiryId, Money amountToPay, IPaymentProcessor paymentProcessor)
    {
        var paymentIntent = paymentProcessor.Initialize(amountToPay);
        PaymentSecret = Guard.Against.Null(paymentIntent, nameof(paymentIntent));;
        ValuationId = Guard.Against.Null(valuationId, nameof(valuationId));
        PaymentId = PaymentId.Create();
        AmountToPay = Guard.Against.Null(amountToPay, nameof(amountToPay));
        InquiryId = Guard.Against.Null(inquiryId, nameof(inquiryId));
        PaymentStatus = PaymentStatus.WaitForPayment;
        var @event = new PaymentInitializedDomainEvent(PaymentId, ValuationId, InquiryId, AmountToPay);
       
        AddDomainEvent(@event);
    }

    public PaymentId PaymentId { get; }
    private ValuationId ValuationId { get; }
    private InquiryId InquiryId { get; }
    private PaymentSecret PaymentSecret { get; }
    private PaymentStatus PaymentStatus { get; set; }
    private Money AmountToPay { get; }

    public static Payment Initialize(ValuationId valuationId, InquiryId inquiryId, Money amountToPay, IPaymentProcessor paymentProcessor)
    {
        return new Payment(valuationId, inquiryId, amountToPay, paymentProcessor);
    }

    public void Pay(IPaymentProcessor paymentProcessor,string token)
    {
        paymentProcessor.Pay(PaymentSecret, token);
        PaymentStatus = PaymentStatus.Payed;
    }
}
