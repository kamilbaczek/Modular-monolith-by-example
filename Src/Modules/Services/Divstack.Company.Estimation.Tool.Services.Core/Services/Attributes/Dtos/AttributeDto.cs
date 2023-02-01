namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PossibleValues.Dtos;

public sealed class AttributeDto
{
    [JsonConstructor]
    public AttributeDto(Guid id, string name, List<PossibleValueDto> possibleValue)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }
}
