namespace Divstack.Company.Estimation.Tool.Emails.Priorities.DeadlineClose.Configuration;

internal interface IPriorityCloseToDeadlineMailConfiguration
{
    string Subject { get; }
    string PathToTemplate { get; }
}
