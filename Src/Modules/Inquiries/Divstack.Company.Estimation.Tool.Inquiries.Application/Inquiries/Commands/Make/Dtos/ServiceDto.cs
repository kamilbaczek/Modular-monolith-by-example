using System;
using System.Collections.Generic;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make.Dtos
{
    public sealed class ServiceDto
    {
        public Guid Id { get; set; }
        public IReadOnlyCollection<AttributeDto> Attributes { get; set; }
    }
}