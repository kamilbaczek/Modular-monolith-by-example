namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries;

public interface IInquiriesRepository
{
    Task PersistAsync(Inquiry inquiry, CancellationToken cancellationToken = default);
}
