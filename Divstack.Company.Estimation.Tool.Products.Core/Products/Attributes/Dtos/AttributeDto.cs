using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Divstack.Company.Estimation.Tool.Products.Core.Attributes.PossibleValues;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.PossibleValues.Dtos;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.Dtos
{
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
}
