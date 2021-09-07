using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Inquiries.Api.Controllers
{
    internal sealed class InquiriesController : BaseController
    {
        private readonly IInquiriesModule _inquiriesModule;

        public InquiriesController(IInquiriesModule inquiriesModule)
        {
            _inquiriesModule = inquiriesModule;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<ActionResult> Make([FromBody] MakeInquiryCommand makeInquiryCommand)
        {
            await _inquiriesModule.ExecuteCommandAsync(makeInquiryCommand);
            return Ok();
        }

    }
}
