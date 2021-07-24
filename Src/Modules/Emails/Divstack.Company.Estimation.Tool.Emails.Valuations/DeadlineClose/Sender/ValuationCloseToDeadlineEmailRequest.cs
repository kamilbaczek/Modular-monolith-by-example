using System;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects;
using Divstack.Company.Estimation.Tool.Shared.DDD.ValueObjects.Emails;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Sender
{
    internal record ValuationCloseToDeadlineEmailRequest(
        int DaysToDeadline,
        string EmployeeEmail,
        Guid ValuationId);
}
