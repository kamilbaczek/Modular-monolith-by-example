using System;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get.Dtos;

namespace Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.Get;

public record GetInquiryQuery(Guid InquiryId) : IQuery<InquiryVm>;
