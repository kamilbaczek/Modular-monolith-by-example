﻿using System;
using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Commands.Make;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get.Dtos;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetAll;
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
            var inquiryId = await _inquiriesModule.ExecuteCommandAsync(makeInquiryCommand);
            return Created(inquiryId);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InquiryVm>> Get(Guid id)
        {
            var inquiries = await _inquiriesModule.ExecuteQueryAsync(new GetInquiryQuery(id));
            return Ok(inquiries);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<InquiryListVm>> GetAll()
        {
            var inquiryListVm = await _inquiriesModule.ExecuteQueryAsync(new GetAllInquiriesQuery());
            return Ok(inquiryListVm);
        }
    }
}