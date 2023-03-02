namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers.Common.Controllers;

using DTO.Errors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ExcludeFromCodeCoverage]
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/users-module/[controller]")]
internal abstract class BaseController : ControllerBase
{
    protected UnauthorizedObjectResult UnauthorizedWithReason(string message)
    {
        return new UnauthorizedObjectResult(new ExceptionDto
        {
            Message = message
        });
    }
}
