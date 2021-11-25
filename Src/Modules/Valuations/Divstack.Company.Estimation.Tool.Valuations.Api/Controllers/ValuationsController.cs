namespace Divstack.Company.Estimation.Tool.Valuations.Api.Controllers;

using Application.Valuations.Commands.ApproveProposal;
using Application.Valuations.Commands.CancelProposal;
using Application.Valuations.Commands.Complete;
using Application.Valuations.Commands.SuggestProposal;
using Application.Valuations.Queries.Get;
using Application.Valuations.Queries.Get.Dtos;
using Application.Valuations.Queries.GetAll;
using Application.Valuations.Queries.GetHistoryById;
using Application.Valuations.Queries.GetHistoryById.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

internal sealed class ValuationsController : BaseController
{
    private readonly IValuationsModule _valuationsModule;

    public ValuationsController(IValuationsModule valuationsModule)
    {
        _valuationsModule = valuationsModule;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ValuationVm>> Get(Guid id)
    {
        var valuationVm = await _valuationsModule.ExecuteQueryAsync(new GetValuationQuery(id));
        return Ok(valuationVm);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ValuationListVm>> GetAll()
    {
        var valuationsListVm = await _valuationsModule.ExecuteQueryAsync(new GetAllValuationsQuery());
        return Ok(valuationsListVm);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("valuations/proposals")]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> SuggestProposal([FromBody] SuggestProposalCommand suggestProposalCommand)
    {
        await _valuationsModule.ExecuteCommandAsync(suggestProposalCommand);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Route("valuations/history/{id}")]
    public async Task<ActionResult<ValuationHistoryVm>> GetHistory(Guid id)
    {
        var valuationHistoryVm = await _valuationsModule.ExecuteQueryAsync(new GetValuationHistoryByIdQuery(id));
        return Ok(valuationHistoryVm);
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("valuations/complete")]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Complete([FromBody] CompleteCommand completeCommand)
    {
        await _valuationsModule.ExecuteCommandAsync(completeCommand);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("valuations/proposals/approve")]
    [ProducesDefaultResponseType]
    [AllowAnonymous]
    public async Task<ActionResult> ApproveProposal([FromQuery] ApproveProposalCommand approveProposalCommand)
    {
        await _valuationsModule.ExecuteCommandAsync(approveProposalCommand);
        return Ok();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("valuations/proposals/reject")]
    [ProducesDefaultResponseType]
    [AllowAnonymous]
    public async Task<ActionResult> RejectProposal([FromQuery] ApproveProposalCommand approveProposalCommand)
    {
        await _valuationsModule.ExecuteCommandAsync(approveProposalCommand);
        return Ok();
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("valuations/proposals/cancel")]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> CancelProposal([FromQuery] CancelProposalCommand cancelProposalCommand)
    {
        await _valuationsModule.ExecuteCommandAsync(cancelProposalCommand);
        return Ok();
    }
}
