namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make.Mappers;

using Domain.Inquiries.Items.Services;
using Domain.Inquiries.Items.Services.Attributes;
using Dtos;

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
