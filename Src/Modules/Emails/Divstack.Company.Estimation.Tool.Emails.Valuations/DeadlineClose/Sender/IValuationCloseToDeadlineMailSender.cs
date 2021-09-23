namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Sender
{
    internal interface IValuationCloseToDeadlineMailSender
    {
        void Send(ValuationCloseToDeadlineEmailRequest request);
    }
}