using System.Linq;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make.Dtos;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Interfaces;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item.Services;
using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Item.Services.Attributes;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make.Mappers
{
    internal sealed class ServiceDtoToServiceMapper : IMapper<AskedServiceDto, Service>
    {
        public Service Map(AskedServiceDto source)
        {
            var service = Service.Create(source.Id);
            source.Attributes
                .ToList()
                .ForEach(AddToService);

            return service;

            void AddToService(AttributeDto attributeDto)
            {
                var attributeId = new AttributeId(attributeDto.AttributeId);
                var attributeValueId = new AttributeValueId(attributeDto.ValueId);
                service.AddAttribute(attributeId, attributeValueId);
            }
        }
    }
}