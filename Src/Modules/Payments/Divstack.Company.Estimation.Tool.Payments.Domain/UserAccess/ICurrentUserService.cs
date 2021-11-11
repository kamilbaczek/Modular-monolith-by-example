using System;

namespace Divstack.Company.Estimation.Tool.Payments.Domain.UserAccess;

public interface ICurrentUserService
{
    Guid GetPublicUserId();
}
