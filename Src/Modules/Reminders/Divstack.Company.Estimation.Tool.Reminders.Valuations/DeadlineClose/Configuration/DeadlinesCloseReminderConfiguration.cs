using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Reminders.Valuations.DeadlineClose.Configuration
{
    internal sealed class DeadlinesCloseReminderConfiguration : IDeadlinesCloseReminderConfiguration
    {
        private readonly IConfigurationSection _configuration;

        public DeadlinesCloseReminderConfiguration(IConfiguration configuration)
        {
            var sectionKey = $"Reminders:{nameof(Valuation)}";
            _configuration = configuration.GetSection(sectionKey);
        }

        public int DaysBeforeDeadline => _configuration.GetValue<int>(nameof(DaysBeforeDeadline));
    }
}