using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Attributes.PossibleValues.Dtos;
using Divstack.Company.Estimation.Tool.Products.Core.Products.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Products.Api.Controllers
{
    internal sealed class PossibleValuesController : BaseController
    {
        private readonly IProductsService _productsService;

        public PossibleValuesController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreatePossibleValues([FromBody] CreatePossibleValueRequest createPossibleValueRequest)
        {
            await _productsService.AddAttributePossibleValueAsync(createPossibleValueRequest);
            return Ok();
        }

        [HttpDelete("{productId}/{attributeId}/{possibleValueId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> RemovePossibleValues(Guid productId, Guid attributeId, Guid possibleValueId)
        {
            await _productsService.RemoveAttributePossibleValueAsync(
                new DeletePossibleValueRequest
                {
                    PossibleValueId = possibleValueId,
                    ProductId = productId,
                    AttributeId = attributeId
                });

            return NoContent();
        }
    }
}
