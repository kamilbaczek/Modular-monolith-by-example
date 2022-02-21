namespace Divstack.Company.Estimation.Tool.Priorities.Api.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Priorities.Queries.GetPrioritiesByValuationsIds.Dtos;

internal sealed class PrioritiesController : BaseController
{
    /// <summary>
    ///     Get batch of priorities
    /// </summary>
    /// <param name="servicesIds">list of guid as parameter. 25 ids per single request allowed</param>
    /// <returns>List of services returned</returns>
    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PrioritiesListVm>> GetBatchAsync([FromQuery] IReadOnlyCollection<Guid> valuationsIds)
    {
        return Ok();
    }
}
