namespace Divstack.Company.Estimation.Tool.Services.Api.Controllers;

using System;
using System.Threading.Tasks;
using Core.Services.Attributes.PossibleValues.Dtos;
using Core.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

internal sealed class PossibleValuesController : BaseController
{
    private readonly IServicesService _servicesService;

    public PossibleValuesController(IServicesService servicesService)
    {
        _servicesService = servicesService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    internal async Task<ActionResult> CreatePossibleValues(
        [FromBody] CreatePossibleValueRequest createPossibleValueRequest)
    {
        await _servicesService.AddAttributePossibleValueAsync(createPossibleValueRequest);
        return Ok();
    }

    [HttpDelete("{serviceId}/{attributeId}/{possibleValueId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    internal async Task<ActionResult> RemovePossibleValues(Guid serviceId, Guid attributeId, Guid possibleValueId)
    {
        await _servicesService.RemoveAttributePossibleValueAsync(
            new DeletePossibleValueRequest
            {
                PossibleValueId = possibleValueId,
                ServiceId = serviceId, 
                AttributeId = attributeId
            });

        return NoContent();
    }
}
