using Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items.Services;

namespace Divstack.Company.Estimation.Tool.Inquiries.Domain.Inquiries.Items;

public sealed class InquiryItem : Entity
{
    private InquiryItem()
    {
    }

    private InquiryItem(Service service, Inquiry inquiry)
    {
        Id = new InquiryItemId(Guid.NewGuid());
        Service = service;
        Inquiry = inquiry;
    }

    private Service Service { get; }
    private InquiryItemId Id { get; }
    private Inquiry Inquiry { get; }

    internal static InquiryItem Create(Service service, Inquiry inquiry)
    {
        return new InquiryItem(service, inquiry);
    }
}
