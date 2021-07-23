namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Configuration
{
    internal interface IValuationCloseToDeadlineMailConfiguration
    {
        string Subject { get; }
        string PathToTemplate { get; }
    }
}
