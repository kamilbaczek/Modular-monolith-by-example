namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.BackgroundProcessing.Configuration;

using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;

internal sealed class BackgroundProcessingConfiguration
{
    private const string BackgroundProcessing = "BackgroundProcessing";

    private readonly IConfigurationSection _configurationSection;
    public BackgroundProcessingConfiguration(IConfiguration configuration)
    {
        _configurationSection = configuration.GetSection(BackgroundProcessing);
    }
    internal string StorageConnectionString => Guard.Against.NullOrEmpty(_configurationSection.GetValue<string>(nameof(StorageConnectionString)), nameof(StorageConnectionString));
}
