namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get;

using Common.Contracts;
using Dtos;

public record GetInquiryQuery(Guid InquiryId) : IQuery<InquiryVm>;
