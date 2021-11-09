using System.Web;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Configuration;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.TemplateReader;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Approved.Sender
{
    internal sealed class ValuationProposalApprovedMailSender : IValuationProposalApprovedMailSender
    {
        private const string ValuationIdPlaceholder = "{ValuationId}";
        private const string ProposalIdPlaceholder = "{ProposalId}";
        private const string ClientEmailPlaceholder = "{ClientEmailPlaceholder}";

        private const string ApprovedLinkPlaceholder = "{ApprovedLink}";

        private const string PriceValuePlaceholder = "{PriceValue}";
        private const string PriceCurrencyPlaceholder = "{PriceCurrency}";

        private readonly IValuationProposalApprovedMailConfiguration _configuration;
        private readonly IEmailSender _emailSender;
        private readonly IMailTemplateReader _mailTemplateReader;

        public ValuationProposalApprovedMailSender(IValuationProposalApprovedMailConfiguration configuration,
            IEmailSender emailSender,
            IMailTemplateReader mailTemplateReader)
        {
            _configuration = configuration;
            _emailSender = emailSender;
            _mailTemplateReader = mailTemplateReader;
        }

        public void Send(ValuationProposalApprovedEmailRequest request)
        {
            var approvedLink = _configuration.ApprovedProposalLink
                .Replace(ValuationIdPlaceholder, HttpUtility.UrlEncode(request.ValuationId.ToString()))
                .Replace(ProposalIdPlaceholder, HttpUtility.UrlEncode(request.ProposalId.ToString()));

            var htmlTemplate = _mailTemplateReader.Read(_configuration.PathToTemplate);
            var emailAsHtml = htmlTemplate
                .Replace(ApprovedLinkPlaceholder, approvedLink)
                .Replace(PriceCurrencyPlaceholder, request.Currency)
                .Replace(ClientEmailPlaceholder, request.SuggestedByEmployeeEmail)
                .Replace(PriceValuePlaceholder, request.Value.ToString());

            _emailSender.Send(request.SuggestedByEmployeeEmail, _configuration.Subject, emailAsHtml);
        }
    }
}