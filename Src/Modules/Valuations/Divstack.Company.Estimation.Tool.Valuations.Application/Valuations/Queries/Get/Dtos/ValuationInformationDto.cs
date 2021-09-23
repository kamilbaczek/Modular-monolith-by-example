using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Constants;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.Get.Dtos
{
    public sealed class ValuationInformationDto
    {
        public ValuationInformationDto(Guid id,
            Guid inquiryId,
            DateTime requestedDate,
            Guid? completedBy,
            string status)
        {
            Id = id;
            InquiryId = inquiryId;
            RequestedDate = requestedDate.ToString(Formatting.DateFormat);
            CompletedBy = completedBy;
            Status = status;
        }

        public Guid Id { get; }
        public Guid InquiryId { get; }
        public string RequestedDate { get; }
        public Guid? CompletedBy { get; }
        public string Status { get; }
    }
}