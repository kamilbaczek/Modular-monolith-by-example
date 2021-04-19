using System;

namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos
{
    public sealed class CreateAttributeRequest
    {
        public string Name { get; set; }
        public Guid ServiceId { get; set; }
    }
}