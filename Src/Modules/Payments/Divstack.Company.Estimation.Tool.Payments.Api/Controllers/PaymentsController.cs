namespace Divstack.Company.Estimation.Tool.Payments.Api.Controllers;

using Application.Common.Contracts;
using Application.Payments.Commands.Charge;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

internal sealed class PaymentsController : BaseController
{
    private readonly IPaymentsModule _paymentsModule;

    public PaymentsController(IPaymentsModule paymentsModule)
    {
        _paymentsModule = paymentsModule;
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    [AllowAnonymous]
    public async Task<ActionResult> Charge([FromBody] ChargeCommand chargeCommand)
    {
        await _paymentsModule.ExecuteCommandAsync(chargeCommand);
        return NoContent();
    }
}
