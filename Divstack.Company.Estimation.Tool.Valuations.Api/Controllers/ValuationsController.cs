﻿using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Valuations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.ApproveProposal;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.CancelProposal;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Complete;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.Request;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Commands.SuggestProposal;
using Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AllowAnonymous]
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

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("valuations/proposals/approve")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ApproveProposal([FromBody] ApproveProposalCommand approveProposalCommand)
        {
            await _valuationsModule.ExecuteCommandAsync(approveProposalCommand);
            return Ok();
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("valuations/proposals/reject")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> RejectProposal([FromBody] ApproveProposalCommand approveProposalCommand)
        {
            await _valuationsModule.ExecuteCommandAsync(approveProposalCommand);
            return Ok();
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("valuations/proposals/cancel")]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelProposal([FromBody] CancelProposalCommand cancelProposalCommand)
        {
            await _valuationsModule.ExecuteCommandAsync(cancelProposalCommand);
            return Ok();
        }
    }
}