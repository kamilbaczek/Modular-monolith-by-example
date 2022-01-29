namespace Divstack.Company.Estimation.Tool.Payments.Api.Controllers;

using Application.Common.Contracts;
using Application.Payments.Commands.Pay;
using IntegrationsEvents.External;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

internal sealed class PaymentsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IPaymentsModule _paymentsModule;

    public PaymentsController(IPaymentsModule paymentsModule, IMediator mediator)
    {
        _paymentsModule = paymentsModule;
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    [AllowAnonymous]
    public async Task<ActionResult> Pay([FromBody] PayCommand payCommand)
    {
        await _paymentsModule.ExecuteCommandAsync(payCommand);

        return NoContent();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    [AllowAnonymous]
    public async Task<ActionResult> Paysss()
    {
        await _mediator.Publish(new PaymentCompleted(Guid.NewGuid(), Guid.Parse("ce4197d1-bd75-4cf1-b238-7341efbc6f0b")));
        return NoContent();
    }
}
