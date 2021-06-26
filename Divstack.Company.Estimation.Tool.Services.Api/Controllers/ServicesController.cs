using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Dtos;
using Divstack.Company.Estimation.Tool.Services.Core.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Services.Api.Controllers
{
    internal sealed class ServicesController : BaseController
    {
        private const int BatchItemsLimit = 25;
        private const string BatchRoute = "batch";
        private readonly IServicesService _servicesService;

        public ServicesController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        /// <summary>
        ///     Get batch of services details
        /// </summary>
        /// <param name="servicesIds">list of guid as parameter. 25 ids per single request allowed</param>
        /// <returns>List of services returned</returns>
        [HttpGet(BatchRoute)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ServiceDto>>> GetBatch([FromQuery] IReadOnlyCollection<Guid> servicesIds)
        {
            var services = await _servicesService.GetBatchAsync(servicesIds, BatchItemsLimit);
            return Ok(services);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ServiceDto>>> GetAll()
        {
            var services = await _servicesService.GetAllAsync();
            return Ok(services);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] CreateServiceRequest createServiceRequest)
        {
            await _servicesService.CreateAsync(createServiceRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _servicesService.DeleteAsync(id);
            return NoContent();
        }
    }
}