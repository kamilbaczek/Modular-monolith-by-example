using System;
using Divstack.Company.Estimation.Tool.Users.Application.Contracts;

namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserEmail
{
    public sealed class GetUserEmailQuery : IQuery<string>
    {
        public GetUserEmailQuery(Guid publicId)
        {
            PublicId = publicId;
        }

        public Guid PublicId { get; }
    }
}