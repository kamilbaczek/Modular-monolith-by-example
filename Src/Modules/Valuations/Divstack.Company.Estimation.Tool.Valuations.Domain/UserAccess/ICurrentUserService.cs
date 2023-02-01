namespace Divstack.Company.Estimation.Tool.Valuations.Domain.UserAccess;

/// <summary>
///   Provides access to the current user 
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    ///    Returns the current user id
    /// </summary>
    /// <returns></returns>
    Guid GetPublicUserId();
}
