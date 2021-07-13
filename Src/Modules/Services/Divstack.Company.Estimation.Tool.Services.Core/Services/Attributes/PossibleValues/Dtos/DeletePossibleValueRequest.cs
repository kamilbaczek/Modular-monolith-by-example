using System;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.PossibleValues.Dtos
{
    public sealed class DeletePossibleValueRequest
    {
        public Guid ServiceId { get; set; }

        public Guid PossibleValueId { get; set; }
        public Guid AttributeId { get; set; }
    }
}