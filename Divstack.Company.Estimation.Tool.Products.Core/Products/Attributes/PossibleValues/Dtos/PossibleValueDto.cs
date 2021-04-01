using System;
using System.Text.Json.Serialization;
using Divstack.Company.Estimation.Tool.Products.Core.Attributes.PossibleValues;

namespace Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.PossibleValues.Dtos
{
    public sealed class PossibleValueDto
    {
        [JsonConstructor]
        public PossibleValueDto(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        internal static PossibleValueDto Map(PossibleValue possibleValue)
        {
            return new PossibleValueDto(possibleValue.Id, possibleValue.Value);
        }
    }
}
