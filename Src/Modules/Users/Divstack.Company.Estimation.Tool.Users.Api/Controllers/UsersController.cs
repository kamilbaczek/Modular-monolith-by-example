namespace Divstack.Company.Estimation.Tool.Users.Api.Controllers;

using System;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Users.Commands.ChangeUserPassword;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.DeleteUser;
using Application.Users.Queries.GetAllUsers;
using Application.Users.Queries.GetUser;
using Common.Controllers;
using Common.DTO.Errors;
using Common.DTO.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

internal sealed class UsersController : BaseController
{
    private readonly IUserModule _userModule;

    public UsersController(IUserModule userModule)
    {
        _userModule = userModule;
    }

    [HttpGet(Name = "GetAllUsers")]
    public async Task<ActionResult<GetAllUsersResponse>> GetAll()
    {
        var usersList = await _userModule.ExecuteQueryAsync(new GetAllUsersQuery());

        return new GetAllUsersResponse
        {
            UserListVm = usersList
        };
    }

    [HttpGet("{id}", Name = "GetUserById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<UserDetailVm>> Get(Guid id)
    {
        var query = new GetUserDetailQuery
        {
            PublicId = id
        };
        return Ok(await _userModule.ExecuteQueryAsync(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ExceptionDto), StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Create([FromBody] CreateUserCommand command)
    {
        await _userModule.ExecuteCommandAsync(command);

        return Ok();
    }

    [HttpDelete("{publicId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid publicId)
    {
        await _userModule.ExecuteCommandAsync(new DeleteUserCommand(publicId));

        return NoContent();
    }


    [HttpPut("ChangeUserPassword")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionDto), StatusCodes.Status500InternalServerError)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> ChangeUserPassword([FromBody] ChangeUserPasswordCommand command)
    {
        await _userModule.ExecuteCommandAsync(command);

        return Ok();
    }
}
