using System;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient.Dtos;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;

public record GetInquiryClientQuery(Guid InquiryId) : IQuery<InquiryClientDto>;
