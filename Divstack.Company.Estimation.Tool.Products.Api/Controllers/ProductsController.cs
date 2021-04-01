using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Dtos;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Products.Api.Controllers
{
    internal sealed class ProductsController : BaseController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var products = await _productsService.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] CreateProductRequest createProductRequest)
        {
            await _productsService.CreateAsync(createProductRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _productsService.DeleteAsync(id);
            return NoContent();
        }


    }
}
