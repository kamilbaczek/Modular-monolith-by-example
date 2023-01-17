namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender;

using System.Web;
using Configuration;
using Core;
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
        var acceptLink = GetAcceptLink(request);
        var rejectLink = GetRejectLink(request);

        var htmlTemplate = _mailTemplateReader.Read(_configuration.PathToTemplate);
        var emailAsHtml = FillEmailTemplate(request, htmlTemplate, acceptLink, rejectLink);

        _emailSender.Send(request.Email, _configuration.Subject, emailAsHtml);

        return Task.CompletedTask;
    }
    private static string FillEmailTemplate(ValuationProposalSuggestedEmailRequest request, string htmlTemplate, string acceptLink, string rejectLink)
    {
        return htmlTemplate
            .Replace(AcceptLinkPlaceholder, acceptLink)
            .Replace(RejectLinkPlaceholder, rejectLink)
            .Replace(FullNamePlaceholder, request.FullName)
            .Replace(DescriptionPlaceholder, request.Description)
            .Replace(PriceCurrencyPlaceholder, request.Currency)
            .Replace(PriceValuePlaceholder, request.Value.ToString());
    }
    private string GetAcceptLink(ValuationProposalSuggestedEmailRequest request)
    {
        var valuationId = HttpUtility.UrlEncode(request.ValuationId.ToString());
        var proposalId = HttpUtility.UrlEncode(request.ProposalId.ToString());

        return _configuration.AcceptProposalLink
             .Replace(ValuationIdPlaceholder, valuationId)
             .Replace(ProposalIdPlaceholder, proposalId);
    }

    private string GetRejectLink(ValuationProposalSuggestedEmailRequest request)
    {
        var valuationId = HttpUtility.UrlEncode(request.ValuationId.ToString());
        var proposalId = HttpUtility.UrlEncode(request.ProposalId.ToString());

        return _configuration.RejectProposalLink
            .Replace(ValuationIdPlaceholder, valuationId)
            .Replace(ProposalIdPlaceholder, proposalId);
    }
}
