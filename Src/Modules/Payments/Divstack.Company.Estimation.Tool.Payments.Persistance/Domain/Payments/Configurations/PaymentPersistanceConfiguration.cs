namespace Divstack.Company.Estimation.Tool.Payments.Persistance.Domain.Payments.Configurations;

using Extensions;
using MongoDB.Bson.Serialization;
using Tool.Payments.Domain.Payments;

internal static class PaymentPersistanceConfiguration
{
    internal static void Configure()
    {
        BsonClassMap.RegisterClassMap<Payment>(classMap =>
        {
            classMap.SetIgnoreExtraElements(true);
            classMap.MapIdProperty(payment => payment.Id).SetElementName("PaymentId");
            classMap.MapProperty("ValuationId").SetIsRequired(true);
            classMap.MapProperty("InquiryId").SetIsRequired(true);
            classMap.MapProperty("PaymentSecret").SetIsRequired(true);
            classMap.MapProperty("PaymentStatus").SetIsRequired(true);
            classMap.MapProperty("AmountToPay").SetIsRequired(true);
            BsonClassMap.RegisterClassMap<ValuationId>(bsonClassMap =>
            {
                bsonClassMap.MapProperty(valuationId => valuationId.Value)
                    .ConfigureIdSerializer()
                    .SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<InquiryId>(bsonClassMap =>
            {
                bsonClassMap.MapProperty(inquiryId => inquiryId.Value)
                    .ConfigureIdSerializer()
                    .SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<PaymentId>(bsonClassMap =>
            {
                bsonClassMap.MapProperty(paymentId => paymentId.Value)
                    .ConfigureIdSerializer()
                    .SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<PaymentStatus>(bsonClassMap =>
            {
                bsonClassMap.MapProperty("Value").SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<PaymentSecret>(bsonClassMap =>
            {
                bsonClassMap.MapProperty("Value").SetIsRequired(true);
            });
        });
    }
}
