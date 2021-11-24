namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Configuration;

using Microsoft.Extensions.Configuration;
using Shared.Abstractions.Configuration;

internal class ValuationCloseToDeadlineMailConfiguration : ConfigurationBase,
    IValuationCloseToDeadlineMailConfiguration
{
    public ValuationCloseToDeadlineMailConfiguration(IConfiguration configuration) : base(configuration,
        nameof(ValuationCloseToDeadlineMailConfiguration))
    {
    }

    public string Subject => configurationSection.GetValue<string>(nameof(Subject));
    public string PathToTemplate => configurationSection.GetValue<string>(nameof(PathToTemplate));
}
