namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos;

using System;

public sealed record CreateAttributeRequest(string Name, Guid ServiceId);
