namespace Divstack.Company.Estimation.Tool.Emails.Priorities.DeadlineClose.Sender;

internal interface IPriorityCloseToDeadlineMailSender
{
    void Send(PriorityCloseToDeadlineEmailRequest request);
}
