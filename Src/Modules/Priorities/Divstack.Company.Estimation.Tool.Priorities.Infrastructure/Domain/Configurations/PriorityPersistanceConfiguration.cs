namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Domain.Configurations;

using Extensions;
using MongoDB.Bson.Serialization;
using Tool.Priorities.Domain;
using Tool.Priorities.Domain.Deadlines;

internal static class PriorityPersistanceConfiguration
{
    internal static void Configure()
    {
        BsonClassMap.RegisterClassMap<Priority>(classMap =>
        {
            classMap.SetIgnoreExtraElements(true);
            classMap.MapIdProperty(priority => priority.Id).SetElementName("PriorityId");
            classMap.MapProperty("ValuationId").SetIsRequired(true);
            classMap.MapProperty("InquiryId").SetIsRequired(true);
            classMap.MapProperty("Scores").SetIsRequired(true);
            classMap.MapProperty("PriorityLevel").SetIsRequired(true);
            classMap.MapProperty("Deadline").SetIsRequired(true);
            classMap.MapProperty("ManualSetLevel").SetIsRequired(false);

            BsonClassMap.RegisterClassMap<ValuationId>(bsonClassMap =>
            {
                bsonClassMap.MapProperty(valuationId => valuationId.Value)
                    .ConfigureIdSerializer()
                    .SetIsRequired(true);
            });

            BsonClassMap.RegisterClassMap<ClientLoseRisk>(bsonClassMap =>
            {
                bsonClassMap.MapProperty("Name")
                    .SetIsRequired(true);
                bsonClassMap.MapProperty("Scores")
                    .SetIsRequired(true);
            });

            BsonClassMap.RegisterClassMap<PriorityLevel>(bsonClassMap =>
            {
                bsonClassMap.MapProperty("Name")
                    .SetIsRequired(true);
                bsonClassMap.MapProperty("Weight")
                    .SetIsRequired(true);
                bsonClassMap.MapProperty("Scores")
                    .SetIsRequired(true);
            });

            BsonClassMap.RegisterClassMap<Deadline>(bsonClassMap =>
            {
                bsonClassMap.MapProperty("Date")
                    .SetIsRequired(true);
            });
        });
    }
}
