namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.Domain.Priorities.Configurations;

using Extensions;
using MongoDB.Bson.Serialization;
using Tool.Priorities.Domain;
using Tool.Priorities.Domain.Deadlines;

internal static class PrioritiesPersistanceConfiguration
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
            classMap.MapProperty("Level").SetIsRequired(true);
            classMap.MapProperty("Deadline").SetIsRequired(true);
            classMap.MapProperty("ManualSetLevel");
            classMap.MapProperty("Archived").SetIsRequired(true).SetDefaultValue(false);
        });
        
        BsonClassMap.RegisterClassMap<PriorityId>(bsonClassMap =>
        {
            bsonClassMap.MapProperty(priorityId => priorityId.Value)
                .ConfigureIdSerializer()
                .SetIsRequired(true);
        });

        BsonClassMap.RegisterClassMap<Deadline>(classMap =>
        {
            classMap.MapProperty("Date").SetIsRequired(true);
        });

        BsonClassMap.RegisterClassMap<ClientLoseRisk>(classMap =>
        {
            classMap.MapProperty("Name").SetIsRequired(true);
            classMap.MapProperty("Scores").SetIsRequired(true);
        });

        BsonClassMap.RegisterClassMap<PriorityLevel>(classMap =>
        {
            classMap.MapProperty("Name").SetIsRequired(true);
            classMap.MapProperty("Scores").SetIsRequired(true);
            classMap.MapProperty("Weight").SetIsRequired(true);
        });
    }
}
