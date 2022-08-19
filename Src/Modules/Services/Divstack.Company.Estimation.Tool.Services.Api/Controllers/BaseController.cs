﻿namespace Divstack.Company.Estimation.Tool.Services.Api.Controllers;

using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/services-module/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
internal abstract class BaseController : ControllerBase
{
    protected CreatedResult Created(Guid id)
    {
        return base.Created(id.ToString(), null);
    }
}
