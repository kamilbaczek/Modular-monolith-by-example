namespace Divstack.Company.Estimation.Tool.Valuations.Persistance.Domain.Valuations.Configurations;

using Extensions;
using MongoDB.Bson.Serialization;
using Tool.Valuations.Domain.Valuations;
using Tool.Valuations.Domain.Valuations.History;
using Tool.Valuations.Domain.Valuations.Proposals;

internal static class ValuationPersistanceConfiguration
{
    internal static void Configure()
    {
        BsonClassMap.RegisterClassMap<Valuation>(classMap =>
        {
            classMap.SetIgnoreExtraElements(true);
            classMap.MapIdProperty(valuation => valuation.Id).SetElementName("ValuationId");
            classMap.MapProperty("RequestedDate").SetIsRequired(true);
            classMap.MapProperty("InquiryId").SetIsRequired(true);
            classMap.MapProperty("CompletedDate");
            classMap.MapProperty("CompletedBy");
            classMap.MapProperty("Proposals");
            classMap.MapProperty("History");
        });
        BsonClassMap.RegisterClassMap<Proposal>(classMap =>
        {
            classMap.MapProperty("Id").SetElementName("ProposalId").SetIsRequired(true);
            classMap.MapProperty("SuggestedBy").SetIsRequired(true);
            classMap.MapProperty("Suggested").SetIsRequired(true);
            classMap.MapProperty("Decision").SetIsRequired(true);
            classMap.MapProperty("Price").SetIsRequired(true);
            classMap.MapProperty("Description").SetIsRequired(true);
        });
        BsonClassMap.RegisterClassMap<EmployeeId>(classMap =>
        {
            classMap.MapProperty(employeeId => employeeId.Value)
                .ConfigureIdSerializer()
                .SetIsRequired(true);
        });
        BsonClassMap.RegisterClassMap<ProposalDescription>(classMap =>
        {
            classMap.MapProperty("Message").SetIsRequired(true);
        });
        BsonClassMap.RegisterClassMap<ProposalDecision>(classMap =>
        {
            classMap.MapProperty("Date").SetIsRequired(false);
            classMap.MapProperty("Code").SetIsRequired(true);
        });
        BsonClassMap.RegisterClassMap<HistoricalEntry>(cm =>
        {
            cm.MapProperty("Id").SetElementName("HistoricalEntryId");
            cm.MapProperty("Status");
            cm.MapProperty("ChangeDate");
        });
        BsonClassMap.RegisterClassMap<ValuationStatus>(cm => { cm.MapProperty("Value"); });
        BsonClassMap.RegisterClassMap<InquiryId>(classMap =>
        {
            classMap.MapProperty("Value")
                .ConfigureIdSerializer()
                .SetIsRequired(true);
        });
        BsonClassMap.RegisterClassMap<HistoricalEntryId>(classMap =>
        {
            classMap.MapProperty("Value")
                .ConfigureIdSerializer()
                .SetIsRequired(true);
        });
        BsonClassMap.RegisterClassMap<ValuationId>(cm =>
        {
            cm.MapProperty("Value")
                .ConfigureIdSerializer()
                .SetIsRequired(true);
        });
        BsonClassMap.RegisterClassMap<ProposalId>(cm =>
        {
            cm.MapProperty("Value")
                .ConfigureIdSerializer()
                .SetIsRequired(true);
        });
    }
}
