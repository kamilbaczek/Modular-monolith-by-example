namespace Divstack.Company.Estimation.Tool.Services.Api.Controllers;

using Core.Services.Categories.Dtos;
using Core.Services.Categories.Services;
using Core.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

[ExcludeFromCodeCoverage]
internal sealed class CategoriesController : BaseController
{
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService) => 
        _categoriesService = categoriesService;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<ServiceDto>>> GetAllAsync()
    {
        var services = await _categoriesService.GetAllAsync();
        return Ok(services);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateCategoryRequest createServiceRequest)
    {
        var categoryId = await _categoriesService.CreateAsync(createServiceRequest);
        return Created(categoryId);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await _categoriesService.DeleteAsync(id);
        return NoContent();
    }
}
