using System;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos
{
    public sealed class DeleteAttributeRequest
    {
        public Guid AttributeId { get; set; }
        public Guid ServiceId { get; set; }
    }
}