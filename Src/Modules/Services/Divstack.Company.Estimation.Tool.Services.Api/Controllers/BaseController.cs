using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Services.Api.Controllers
{
    [ApiController]
    [Route("api/services-module/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    internal abstract class BaseController : ControllerBase
    {
    }
}