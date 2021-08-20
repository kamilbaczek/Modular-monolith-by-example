using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Valuations.Infrastructure.Snov.FindClientCompany.ApiConsumer.Dtos.ClientProfile
{
    internal record ClientProfileDto(IReadOnlyCollection<CurrentJobDto> CurrentJobs);
}
