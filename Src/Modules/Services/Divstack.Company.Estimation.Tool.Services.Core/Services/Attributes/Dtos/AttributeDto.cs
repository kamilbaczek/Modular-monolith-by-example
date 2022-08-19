namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using PossibleValues.Dtos;
using Attribute = Attributes.Attribute;

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
    public List<PossibleValueDto> PossibleValues { get; }

    internal static AttributeDto Map(Attribute attribute)
    {
        var possibleValues = attribute.PossibleValues.Select(PossibleValueDto.Map).ToList();
        return new AttributeDto(attribute.Id, attribute.Name, possibleValues);
    }
}
