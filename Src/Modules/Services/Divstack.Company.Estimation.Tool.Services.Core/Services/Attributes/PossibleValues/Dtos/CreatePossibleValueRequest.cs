using System;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues.Dtos
{
    public sealed class CreatePossibleValueRequest
    {
        public string Value { get; set; }
        public Guid ServiceId { get; set; }
        public Guid AttributeId { get; set; }
    }
}