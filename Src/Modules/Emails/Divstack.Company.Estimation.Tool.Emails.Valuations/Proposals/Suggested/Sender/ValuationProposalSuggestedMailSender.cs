using System.Threading.Tasks;
using System.Web;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Configuration;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.TemplateReader;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Sender
{
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
        private readonly IEmailModule _emailModule;
        private readonly IMailTemplateReader _mailTemplateReader;

        public ValuationProposalSuggestedMailSender(ISuggestValuationMailConfiguration configuration,
            IEmailModule emailModule,
            IMailTemplateReader mailTemplateReader)
        {
            _configuration = configuration;
            _emailModule = emailModule;
            _mailTemplateReader = mailTemplateReader;
        }

        public async Task SendEmailAsync(ValuationProposalSuggestedEmailRequest request)
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
                .Replace(PriceCurrencyPlaceholder, request.Value.Currency)
                .Replace(PriceValuePlaceholder, request.Value.Value.ToString());

            await _emailModule.SendEmailAsync(request.ClientEmail, _configuration.Subject, emailAsHtml);
        }
    }
}