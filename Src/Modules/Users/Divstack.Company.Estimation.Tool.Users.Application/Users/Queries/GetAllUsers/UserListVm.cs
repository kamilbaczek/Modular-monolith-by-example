using System.Collections.Generic;
using MediatR;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetAllUsers;

public record UserListVm(IList<UserDto> Users) : IRequest<Unit>;
