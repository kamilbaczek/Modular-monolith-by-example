namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Sender;

using System;

internal record ValuationCloseToDeadlineEmailRequest(
    int DaysToDeadline,
    string EmployeeEmail,
    Guid ValuationId);
