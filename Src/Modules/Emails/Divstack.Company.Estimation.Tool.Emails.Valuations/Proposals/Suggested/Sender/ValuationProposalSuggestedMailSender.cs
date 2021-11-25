namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender;

using System.Web;
using Configuration;
using Core.Sender.Contracts;
using Core.Sender.TemplateReader;

internal sealed class ValuationProposalSuggestedMailSender : IValuationProposalSuggestedMailSender
{
    private const string ValuationIdPlaceholder = "{ValuationId}";
    private const string ProposalIdPlaceholder = "{ProposalId}";

    private const string AcceptLinkPlaceholder = "{AcceptLink}";
    private const string RejectLinkPlaceholder = "{RejectLink}";

    private const string FullNamePlaceholder = "{FullName}";
    private const string DescriptionPlaceholder = "{Description}";
    private const string PriceValuePlaceholder = "{PriceValue}";
    private const string PriceCurrencyPlaceholder = "{PriceCurrency}";

    private readonly ISuggestValuationMailConfiguration _configuration;
    private readonly IEmailSender _emailSender;
    private readonly IMailTemplateReader _mailTemplateReader;

    public ValuationProposalSuggestedMailSender(
        ISuggestValuationMailConfiguration configuration,
        IEmailSender emailSender,
        IMailTemplateReader mailTemplateReader)
    {
        _configuration = configuration;
        _emailSender = emailSender;
        _mailTemplateReader = mailTemplateReader;
    }

    public Task SendAsync(ValuationProposalSuggestedEmailRequest request)
    {
        var acceptLink = _configuration.AcceptProposalLink
            .Replace(ValuationIdPlaceholder, HttpUtility.UrlEncode(request.ValuationId.ToString()))
            .Replace(ProposalIdPlaceholder, HttpUtility.UrlEncode(request.ProposalId.ToString()));

        var rejectLink = _configuration.RejectProposalLink
            .Replace(ValuationIdPlaceholder, HttpUtility.UrlEncode(request.ValuationId.ToString()))
            .Replace(ProposalIdPlaceholder, HttpUtility.UrlEncode(request.ProposalId.ToString()));

        var htmlTemplate = _mailTemplateReader.Read(_configuration.PathToTemplate);
        var emailAsHtml = htmlTemplate
            .Replace(AcceptLinkPlaceholder, acceptLink)
            .Replace(RejectLinkPlaceholder, rejectLink)
            .Replace(FullNamePlaceholder, request.FullName)
            .Replace(DescriptionPlaceholder, request.Description)
            .Replace(PriceCurrencyPlaceholder, request.Currency)
            .Replace(PriceValuePlaceholder, request.Value.ToString());

        _emailSender.Send(request.Email, _configuration.Subject, emailAsHtml);
        return Task.CompletedTask;
    }
}
