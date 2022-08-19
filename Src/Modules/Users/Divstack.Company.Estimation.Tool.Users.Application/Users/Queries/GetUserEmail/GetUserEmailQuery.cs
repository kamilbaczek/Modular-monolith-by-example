namespace Divstack.Company.Estimation.Tool.Users.Application.Users.Queries.GetUserEmail;

using System;
using Contracts;

public sealed class GetUserEmailQuery : IQuery<string>
{
    public GetUserEmailQuery(Guid publicId)
    {
        PublicId = publicId;
    }

    public Guid PublicId { get; }
}
