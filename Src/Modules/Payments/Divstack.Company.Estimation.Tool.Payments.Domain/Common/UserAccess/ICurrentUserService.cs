namespace Divstack.Company.Estimation.Tool.Payments.Domain.Common.UserAccess;

public interface ICurrentUserService
{
    Guid GetPublicUserId();
}
