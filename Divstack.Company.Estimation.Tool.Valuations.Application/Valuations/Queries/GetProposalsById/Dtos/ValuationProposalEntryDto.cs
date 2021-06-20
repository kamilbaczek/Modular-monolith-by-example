using System;
using Divstack.Company.Estimation.Tool.Valuations.Application.Constants;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetProposalsById.Dtos
{
    public record ValuationProposalEntryDto(
        Guid Id,
        string Message,
        string Currency,
        decimal Value,
        DateTime? Suggested,
        Guid? SuggestedBy,
        DateTime? DecisionDate,
        string Decision)
    {
        internal DateTime? Suggested { get;} = Suggested;

        public string SuggestedFormatted =>
            Suggested.HasValue ? Suggested.Value.ToString(Formatting.DateTimeFormat) : string.Empty;

        internal DateTime? DecisionDate { get;} = DecisionDate;

        public string DecisionDateFormatted =>
            DecisionDate.HasValue ? DecisionDate.Value.ToString(Formatting.DateTimeFormat) : string.Empty;
    };
}
