namespace Divstack.Company.Estimation.Tool.Priorities.Persistance.Domain.Priorities.Configurations.Extensions;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

internal static class MongoMappingsExtensions
{
    internal static BsonMemberMap ConfigureIdSerializer(this BsonMemberMap bsonMemberMap)
    {
        var bsonSerializer = new GuidSerializer(BsonType.String);
        return bsonMemberMap.SetSerializer(bsonSerializer);
    }
}
