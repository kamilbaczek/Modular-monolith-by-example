using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Estimations.Application.Contracts;
using Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.ApproveProposal;
using Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.CancelProposal;
using Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.Complete;
using Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.Request;
using Divstack.Company.Estimation.Tool.Estimations.Application.Valuations.Commands.SuggestProposal;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<ActionResult> Request([FromBody] RequestCommand requestCommand)
        {
            await _valuationsModule.ExecuteCommandAsync(requestCommand);
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
