using System;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUser
{
    public class GetUserDetailQuery : IQuery<UserDetailVm>
    {
        public Guid PublicId { get; set; }
    }
}