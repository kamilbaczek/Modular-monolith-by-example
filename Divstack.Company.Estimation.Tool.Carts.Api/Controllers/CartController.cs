using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.AddItem;
using Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.ClearItems;
using Divstack.Company.Estimation.Tool.Carts.Application.Carts.Commands.DeleteItem;
using Divstack.Company.Estimation.Tool.Carts.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Carts.Api.Controllers
{
    internal sealed class CartController : BaseController
    {
        private readonly ICartModule _cartModule;

        public CartController(ICartModule cartModule)
        {
            _cartModule = cartModule;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] AddItemCommand addItemCommand)
        {
            await _cartModule.ExecuteCommandAsync(addItemCommand);
            return Ok();
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteItem(Guid productId)
        {
            var deleteItemCommand = new DeleteItemCommand(productId);
            await _cartModule.ExecuteCommandAsync(deleteItemCommand);

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Clear()
        {
            var clearCommand = new ClearItemsCommand();
            await _cartModule.ExecuteCommandAsync(clearCommand);

            return NoContent();
        }
    }
}
