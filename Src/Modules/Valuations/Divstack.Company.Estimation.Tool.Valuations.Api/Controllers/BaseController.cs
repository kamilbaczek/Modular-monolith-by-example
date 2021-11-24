namespace Divstack.Company.Estimation.Tool.Valuations.Api.Controllers;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/valuations-module/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
internal abstract class BaseController : ControllerBase
{
}
