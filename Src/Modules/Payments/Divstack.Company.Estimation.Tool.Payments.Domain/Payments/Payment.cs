namespace Divstack.Company.Estimation.Tool.Payments.Domain.Payments;

using Events;
using Exceptions;

public sealed class Payment : Entity, IAggregateRoot
{
    private Payment(ValuationId valuationId, InquiryId inquiryId, Money amountToPay, PaymentSecret paymentSecret)
    {
        Id = PaymentId.Create();
        PaymentSecret = Guard.Against.Null(paymentSecret);
        ValuationId = Guard.Against.Null(valuationId);
        AmountToPay = Guard.Against.Null(amountToPay);
        InquiryId = Guard.Against.Null(inquiryId);
        PaymentStatus = PaymentStatus.WaitForPayment;
        var @event = new PaymentInitializedDomainEvent(Id, ValuationId, InquiryId, AmountToPay);

        AddDomainEvent(@event);
    }

    public PaymentId Id { get; init; }
    private ValuationId ValuationId { get; init; }
    private InquiryId InquiryId { get; init; }
    private PaymentSecret PaymentSecret { get; init; }
    private PaymentStatus PaymentStatus { get; set; }
    private Money AmountToPay { get; init; }

    public static async Task<Payment> InitializeAsync(ValuationId valuationId, InquiryId inquiryId, Money amountToPay, IPaymentProcessor paymentProcessor)
    {
        var paymentSecret = await paymentProcessor.InitializeAsync(amountToPay);
        var payment = new Payment(valuationId, inquiryId, amountToPay, paymentSecret);

        return payment;
    }

    public async Task PayCard(
        IPaymentProcessor paymentProcessor,
        Card card)
    {
        if (PaymentStatus == PaymentStatus.Payed)
            throw new PaymentAlreadyPayedException(Id);
        await paymentProcessor.PayAsync(PaymentSecret, card);
        PaymentStatus = PaymentStatus.Payed;
        var @event = new PaymentCompletedDomainEvent(Id, InquiryId);

        AddDomainEvent(@event);
    }
}
