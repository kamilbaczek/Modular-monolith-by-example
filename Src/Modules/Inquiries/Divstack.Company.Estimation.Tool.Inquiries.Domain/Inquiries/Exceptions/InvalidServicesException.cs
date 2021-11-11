namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Exceptions;

public sealed class InvalidServicesException : InvalidOperationException
{
    public InvalidServicesException(IReadOnlyCollection<Guid> servicesIds) :
        base($"Not all services exist: {string.Join(',', servicesIds)}")
    {
    }
}
