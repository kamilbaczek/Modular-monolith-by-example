namespace Divstack.Company.Estimation.Tool.Inquiries.Infrastructure.Snov.FindClientCompany.ApiConsumer.Dtos.
    ClientProfile;

using System.Collections.Generic;

internal record ClientProfileDto(IReadOnlyCollection<CurrentJobDto> CurrentJobs);
