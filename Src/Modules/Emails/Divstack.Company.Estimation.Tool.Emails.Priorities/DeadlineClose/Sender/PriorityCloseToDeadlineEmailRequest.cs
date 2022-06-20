namespace Divstack.Company.Estimation.Tool.Emails.Priorities.DeadlineClose.Sender;

internal record PriorityCloseToDeadlineEmailRequest(
    int DaysToDeadline,
    string EmployeeEmail,
    Guid ValuationId);
