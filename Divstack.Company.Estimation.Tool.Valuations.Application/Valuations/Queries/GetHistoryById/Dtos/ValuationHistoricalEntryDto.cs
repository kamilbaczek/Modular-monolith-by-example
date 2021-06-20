using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Constants;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetHistoryById.Dtos
{
    public record ValuationHistoricalEntryDto(Guid Id, string Status, DateTime ChangeDate)
    {
        internal DateTime ChangeDate { get;} = ChangeDate;
        public string ChangeDateFormatted => ChangeDate.ToString(Formatting.DateTimeFormat);
    };
}
