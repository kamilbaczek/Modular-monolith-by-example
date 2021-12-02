namespace Divstack.Company.Estimation.Tool.Services.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Services.Categories.Dtos;
using Core.Services.Categories.Services;
using Core.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

internal sealed class CategoriesController : BaseController
{
    private readonly ICategoriesService _categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        _categoriesService = categoriesService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    internal async Task<ActionResult<List<ServiceDto>>> GetAll()
    {
        var services = await _categoriesService.GetAllAsync();
        return Ok(services);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    internal async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryRequest createServiceRequest)
    {
        var categoryId = await _categoriesService.CreateAsync(createServiceRequest);
        return Created(categoryId);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    internal async Task<ActionResult> Delete(Guid id)
    {
        await _categoriesService.DeleteAsync(id);
        return NoContent();
    }
}
