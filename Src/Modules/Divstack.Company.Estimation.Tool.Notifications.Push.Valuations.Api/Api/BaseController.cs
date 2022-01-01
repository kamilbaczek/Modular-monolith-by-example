﻿namespace Divstack.Company.Estimation.Tool.Notifications.Push.Valuations.Persistance.Api;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/notifications-module/[controller]")]
internal abstract class BaseController : ControllerBase
{
}