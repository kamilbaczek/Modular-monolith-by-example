namespace Divstack.Company.Estimation.Tool.Services.Api.Controllers;

using System;
using System.Threading.Tasks;
using Core.Services.Attributes.Dtos;
using Core.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

internal sealed class AttributesController : BaseController
{
    private readonly IServicesService _servicesService;

    public AttributesController(IServicesService servicesService)
    {
        _servicesService = servicesService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CreateAttribute([FromBody] CreateAttributeRequest createAttributeRequest)
    {
        await _servicesService.AddAttributeAsync(createAttributeRequest);
        return Ok();
    }

    [HttpDelete("{serviceId}/{attributeId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RemoveAttribute(Guid serviceId, Guid attributeId)
    {
        var removeAttributeRequest = new RemoveAttributeRequest
        {
            ServiceId = serviceId,
            AttributeId = attributeId
        };
        await _servicesService.RemoveAttributeAsync(removeAttributeRequest);

        return NoContent();
    }
}
