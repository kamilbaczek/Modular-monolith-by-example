namespace Divstack.Company.Estimation.Tool.Priorities.Domain.Tests.Common.Builders;

using Deadlines;

internal sealed class PrioritiesBuilder
{
    private const int WorksDaysToDeadlineFromNow = 3;

    internal PrioritiesBuilder()
    {
        InquiryId = InquiryId.Create();
        Deadline = A.Deadline().WithDeadline(WorksDaysToDeadlineFromNow);
        InquiryId = InquiryId.Create(new Guid());
        ValuationId = ValuationId.Create(new Guid());
        CompanySize = 100;
    }
    private static InquiryId? InquiryId { get; set; }
    private static ValuationId? ValuationId { get; set; }
    private static Deadline? Deadline { get; set; }
    private static int CompanySize { get; set; }

    internal PrioritiesBuilder WithDeadline(int worksDaysToDeadlineFromNow)
    {
        Deadline = A.Deadline().WithDeadline(worksDaysToDeadlineFromNow);
        return this;
    }

    internal PrioritiesBuilder WithValuation(Guid valuationId)
    {
        ValuationId = ValuationId.Create(valuationId);
        return this;
    }

    internal PrioritiesBuilder WithCompanySize(int companySize)
    {
        CompanySize = companySize;

        return this;
    }

    internal PrioritiesBuilder WithInquiry(Guid inquiryId)
    {
        InquiryId = InquiryId.Create(inquiryId);
        return this;
    }

    private static Priority Build()
    {
        return Priority.Define(ValuationId, InquiryId, CompanySize, Deadline);
    }

    public static implicit operator Priority(PrioritiesBuilder builder)
    {
        return Build();
    }
}
