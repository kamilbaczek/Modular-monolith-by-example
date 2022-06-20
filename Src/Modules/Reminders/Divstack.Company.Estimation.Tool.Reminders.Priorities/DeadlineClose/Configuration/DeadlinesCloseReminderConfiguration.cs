namespace Divstack.Company.Estimation.Tool.Reminders.Priorities.DeadlineClose.Configuration;

using Microsoft.Extensions.Configuration;
using Tool.Priorities.Domain;

internal sealed class DeadlinesCloseReminderConfiguration : IDeadlinesCloseReminderConfiguration
{
    private readonly IConfigurationSection _configuration;

    public DeadlinesCloseReminderConfiguration(IConfiguration configuration)
    {
        const string sectionKey = $"Reminders:{nameof(Priority)}";
        _configuration = configuration.GetSection(sectionKey);
    }

    public int DaysBeforeDeadline => _configuration.GetValue<int>(nameof(DaysBeforeDeadline));
}
