namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;

using Common.Contracts;
using Dtos;

public record GetInquiryClientQuery(Guid InquiryId) : IQuery<InquiryClientDto>;
