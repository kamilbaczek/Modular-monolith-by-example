using System;

namespace Divstack.Company.Estimation.Tool.Valuations.Application.Valuations.Queries.GetAll
{
    public record ValuationListItemDto(
        Guid Id,
        string FirstName,
        string LastName,
        DateTime RequestedDate,
        Guid? CompletedBy)
    {
        public string FullName => $"{FirstName} {LastName}";
    }
}
