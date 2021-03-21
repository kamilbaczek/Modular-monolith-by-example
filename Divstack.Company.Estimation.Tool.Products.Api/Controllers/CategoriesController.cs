using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories.Dtos;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Categories.Services;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Products.Api.Controllers
{
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
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var products = await _categoriesService.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] CreateCategoryRequest createProductRequest)
        {
            await _categoriesService.CreateAsync(createProductRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _categoriesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
