namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;

public sealed record UpdateServiceRequest(string Name, string Description, Guid CategoryId, Guid ServiceId);
