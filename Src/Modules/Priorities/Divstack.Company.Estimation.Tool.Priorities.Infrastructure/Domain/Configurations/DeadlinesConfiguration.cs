namespace Divstack.Company.Estimation.Tool.Priorities.Infrastructure.Domain.Configurations;

using Microsoft.Extensions.Configuration;
using Tool.Priorities.Domain;
using Tool.Priorities.Domain.Deadlines;

internal sealed class DeadlinesConfiguration : IDeadlinesConfiguration
{
    private readonly IConfigurationSection _configuration;
    public DeadlinesConfiguration(IConfiguration configuration)
    {
        const string sectionKey = $"{nameof(Priority)}:{nameof(Deadline)}";
        _configuration = configuration.GetSection(sectionKey);
    }

    public int WorksDaysToDeadlineFromNow => _configuration.GetValue<int>(nameof(WorksDaysToDeadlineFromNow));
}
