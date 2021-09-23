using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Inquiries.Api.Controllers
{
    [ApiController]
    [Route("api/inquries-module/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    internal abstract class BaseController : ControllerBase
    {
    }
}