using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.Dtos;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Products.Api.Controllers
{
    internal sealed class AttributesController : BaseController
    {
        private readonly IProductsService _productsService;

        public AttributesController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateAttribute([FromBody] CreateAttributeRequest createAttributeRequest)
        {
            await _productsService.AddAttributeAsync(createAttributeRequest);
            return Ok();
        }

        [HttpDelete("{productId}/{attributeId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemoveAttribute(Guid productId, Guid attributeId)
        {
            await _productsService.RemoveAttributeAsync(new DeleteAttributeRequest
            {
                ProductId = productId,
                AttributeId = attributeId
            });

            return NoContent();
        }
    }
}
