namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetAllUsers;

using System.Collections.Generic;
using MediatR;

public record UserListVm(IList<UserDto> Users) : IRequest<Unit>;
