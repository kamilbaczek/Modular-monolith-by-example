using System;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Sender
{
    internal record ValuationCloseToDeadlineEmailRequest(
        int DaysToDeadline,
        string EmployeeEmail,
        Guid ValuationId);
}