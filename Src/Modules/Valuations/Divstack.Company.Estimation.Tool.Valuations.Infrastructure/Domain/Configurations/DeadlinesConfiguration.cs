namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Domain.Configurations;

using Microsoft.Extensions.Configuration;
using Valuations.Domain.Valuations;
using Valuations.Domain.Valuations.Deadlines;

internal sealed class DeadlinesConfiguration : IDeadlinesConfiguration
{
    private readonly IConfigurationSection _configuration;

    public DeadlinesConfiguration(IConfiguration configuration)
    {
        var sectionKey = $"{nameof(Valuation)}:{nameof(Deadline)}";
        _configuration = configuration.GetSection(sectionKey);
    }

    public int WorksDaysToDeadlineFromNow => _configuration.GetValue<int>(nameof(WorksDaysToDeadlineFromNow));
}
