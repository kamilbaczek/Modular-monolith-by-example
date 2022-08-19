namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Sender;

internal interface IValuationProposalApprovedMailSender
{
    void Send(ValuationProposalApprovedEmailRequest request);
}
