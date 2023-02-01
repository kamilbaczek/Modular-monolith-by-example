namespace Divstack.Company.Estimation.Tool.Services.Core.Services.Exceptions;

internal sealed class ServiceNotFoundException : InvalidOperationException
{
    public ServiceNotFoundException(Guid id) : base($"Service: {id} not found")
    {
    }
}
