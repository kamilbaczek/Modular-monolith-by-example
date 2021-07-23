using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations;
using Divstack.Company.Estimation.Tool.Valuations.Domain.Valuations.Deadlines;
using Microsoft.Extensions.Configuration;

namespace Divstack.Company.Estimation.Tool.Estimations.Infrastructure.Domain.Configurations
{
    internal sealed class DeadlinesConfiguration : IDeadlinesConfiguration
    {
        private readonly IConfigurationSection _configuration;

        public DeadlinesConfiguration(IConfiguration configuration)
        {
            _configuration = configuration.GetSection($"{nameof(Valuation)}:{nameof(Deadline)}");
        }

        public int WorksDaysToDeadlineFromNow => _configuration.GetValue<int>(nameof(WorksDaysToDeadlineFromNow));
    }
}
