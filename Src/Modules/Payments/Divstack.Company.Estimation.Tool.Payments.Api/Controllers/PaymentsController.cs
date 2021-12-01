namespace Divstack.Company.Estimation.Tool.Payments.Api.Controllers;

using Application.Common.Contracts;
using Application.Payments.Commands.Pay;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

internal sealed class PaymentsController : BaseController
{
    private readonly IPaymentsModule _paymentsModule;

    internal PaymentsController(IPaymentsModule paymentsModule)
    {
        _paymentsModule = paymentsModule;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    [AllowAnonymous]
    internal async Task<ActionResult> Pay([FromBody] PayCommand payCommand)
    {
        await _paymentsModule.ExecuteCommandAsync(payCommand);
        return NoContent();
    }
}
