namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault;

using Secrets;

internal static class KeyVaultSecrets
{
    internal const string MongoDb = nameof(MongoDb);
    internal const string MySqlDb = nameof(MySqlDb);
    internal const string PostgresDb = nameof(PostgresDb);
    internal const string AuthTokenSecret = nameof(AuthTokenSecret);
    internal const string StripeApi = nameof(StripeApi);
    internal const string TrelloAppKey = nameof(TrelloAppKey);
    internal const string TrelloUserKey = nameof(TrelloUserKey);
    internal const string EventBusEndpointKey = nameof(EventBusEndpointKey);


    internal static readonly IReadOnlyCollection<KeyVaultSecret> Secrets =
        new List<KeyVaultSecret>
    {
        new(StripeApi, new List<SecuredAppConfigKey>
        {
            new("StripeApi:ApiKey"),
        }),
        new(AuthTokenSecret, new List<SecuredAppConfigKey>
        {
            new("TokenConfiguration:Secret"),
        }),
        new(MongoDb, new List<SecuredAppConfigKey>
        {
            new("ConnectionStrings:Inquiries"),
            new("ConnectionStrings:Payments"),
            new("ConnectionStrings:Priorities"),
            new("ConnectionStrings:Notifications"),
            new("BackgroundProcessing:StorageConnectionString"),
            new("Storage:ConnectionString")
        }),
        new(MySqlDb, new List<SecuredAppConfigKey>
        {
            new("ConnectionStrings:Users"),
        }),
        new(PostgresDb, new List<SecuredAppConfigKey>
        {
            new("ConnectionStrings:Valuations")
        }),
        new(TrelloAppKey, new List<SecuredAppConfigKey>
        {
            new("Trello:AppKey")
        }),
        new(TrelloUserKey, new List<SecuredAppConfigKey>
        {
            new("Trello:UserToken")
        }),
        new(EventBusEndpointKey, new List<SecuredAppConfigKey>
        {
            new("EventBus:ConnectionString")
        })
    };
}
