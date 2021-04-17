using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Attributes.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Services.Api.Controllers
{
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
            await _servicesService.RemoveAttributeAsync(new DeleteAttributeRequest
            {
                ServiceId = serviceId,
                AttributeId = attributeId
            });

            return NoContent();
        }
    }
}
