namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUser;

using System;
using Contracts;

public class GetUserDetailQuery : IQuery<UserDetailVm>
{
    public Guid PublicId { get; set; }
}
