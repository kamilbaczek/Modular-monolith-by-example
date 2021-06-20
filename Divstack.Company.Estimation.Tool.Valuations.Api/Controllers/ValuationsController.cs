using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.CancelProposal;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Complete;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Estimations.Api.Controllers
{
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
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<ActionResult> Request([FromBody] RequestValuationCommand requestValuationCommand)
        {
            await _valuationsModule.ExecuteCommandAsync(requestValuationCommand);
            return Ok();
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
        public async Task<ActionResult> Complete([FromBody] CompleteCommand suggestProposalCommand)
        {
            await _valuationsModule.ExecuteCommandAsync(suggestProposalCommand);
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
}
