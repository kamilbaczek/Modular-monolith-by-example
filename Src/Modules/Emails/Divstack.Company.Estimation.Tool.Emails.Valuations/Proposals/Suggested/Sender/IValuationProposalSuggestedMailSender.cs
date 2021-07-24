namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender
{
    internal interface IValuationProposalSuggestedMailSender
    {
        void Send(ValuationProposalSuggestedEmailRequest request);
    }
}
