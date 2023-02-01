namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues.Dtos;

using System;

public sealed record CreatePossibleValueRequest(string Value, Guid ServiceId, Guid AttributeId);
