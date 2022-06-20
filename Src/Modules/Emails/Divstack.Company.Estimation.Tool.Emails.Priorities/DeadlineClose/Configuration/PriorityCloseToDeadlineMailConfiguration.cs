namespace Divstack.Company.Estimation.Tool.Emails.Priorities.DeadlineClose.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal sealed class PriorityCloseToDeadlineMailConfiguration : ConfigurationBase,
    IPriorityCloseToDeadlineMailConfiguration
{
    public PriorityCloseToDeadlineMailConfiguration(IConfiguration configuration) : base(configuration,
        nameof(PriorityCloseToDeadlineMailConfiguration))
    {
    }

    public string Subject => configurationSection.GetValue<string>(nameof(Subject));
    public string PathToTemplate => configurationSection.GetValue<string>(nameof(PathToTemplate));
}
