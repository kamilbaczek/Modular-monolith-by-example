using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany.ApiConsumer.Dtos.
    ClientProfile
{
    internal record ClientProfileDto(IReadOnlyCollection<CurrentJobDto> CurrentJobs);
}