namespace Divstack.Company.Estimation.Tool.Payments.Persistance.Domain.Payments.Configurations;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Shared.DDD.ValueObjects;
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
            BsonClassMap.RegisterClassMap<ValuationId>(classMap =>
            {
                classMap.MapProperty(valuationId => valuationId.Value)
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<InquiryId>(classMap =>
            {
                classMap.MapProperty(inquiryId => inquiryId.Value)
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<PaymentId>(classMap =>
            {
                classMap.MapProperty(paymentId => paymentId.Value)
                    .SetSerializer(new GuidSerializer(BsonType.String))
                    .SetIsRequired(true);
            });
            
            BsonClassMap.RegisterClassMap<PaymentStatus>(classMap =>
            {
                classMap.MapProperty("Value").SetIsRequired(true);
            });
            BsonClassMap.RegisterClassMap<PaymentSecret>(classMap =>
            {
                classMap.MapProperty("Value").SetIsRequired(true);
            });
        });
       
    }
}
