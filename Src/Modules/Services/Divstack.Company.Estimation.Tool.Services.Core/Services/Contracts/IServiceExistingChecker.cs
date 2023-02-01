namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Contracts;

using System.Collections.Generic;
using System.Threading.Tasks;

public interface IServiceExistingChecker
{
    Task<bool> ExistAsync(Guid serviceId);
    Task<bool> ExistAsync(IReadOnlyCollection<Guid> serviceIds);
}
