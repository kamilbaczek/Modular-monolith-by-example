using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Constants;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll
{
    public sealed class ValuationListItemDto
    {
        public ValuationListItemDto(Guid id,
            Guid inquiryId,
            string status,
            DateTime requestedDate,
            Guid? completedBy)
        {
            Id = id;
            InquiryId = inquiryId;
            Status = status;
            RequestedDate = requestedDate.ToString(Formatting.DateFormat);
            CompletedBy = completedBy;
        }

        public Guid Id { get; }
        public Guid InquiryId { get; }
        public string Status { get; }
        public string RequestedDate { get; }
        public Guid? CompletedBy { get; }
    }
}