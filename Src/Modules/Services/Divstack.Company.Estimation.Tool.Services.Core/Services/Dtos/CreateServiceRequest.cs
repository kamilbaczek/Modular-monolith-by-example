namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

using System;

public sealed record CreateServiceRequest(Guid CategoryId, string Name, string Description);
