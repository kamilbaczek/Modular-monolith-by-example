namespace Divstack.Company.Estimation.Tool.Valuations.Domain.UserAccess;

using System;

public interface ICurrentUserService
{
    Guid GetPublicUserId();
}
