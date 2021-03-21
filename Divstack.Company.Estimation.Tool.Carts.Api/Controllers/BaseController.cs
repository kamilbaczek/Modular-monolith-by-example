using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Divstack.Company.Estimation.Tool.Carts.Api.Controllers
{
    [ApiController]
    [Route("api/carts-module/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    internal abstract class BaseController : ControllerBase
    {
    }
}
