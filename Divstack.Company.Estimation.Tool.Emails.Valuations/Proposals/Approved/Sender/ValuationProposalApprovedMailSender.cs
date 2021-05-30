using System.Threading.Tasks;
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
        private readonly IEmailModule _emailModule;
        private readonly IMailTemplateReader _mailTemplateReader;

        public ValuationProposalApprovedMailSender(IValuationProposalApprovedMailConfiguration configuration,
            IEmailModule emailModule,
            IMailTemplateReader mailTemplateReader)
        {
            _configuration = configuration;
            _emailModule = emailModule;
            _mailTemplateReader = mailTemplateReader;
        }

        public async Task SendEmailAsync(ValuationProposalApprovedEmailRequest request)
        {
            var approvedLink = _configuration.ApprovedProposalLink
                .Replace(ValuationIdPlaceholder, HttpUtility.UrlEncode(request.ValuationId.ToString()))
                .Replace(ProposalIdPlaceholder, HttpUtility.UrlEncode(request.ProposalId.ToString()));

            var htmlTemplate = _mailTemplateReader.Read(_configuration.PathToTemplate);
            var emailAsHtml = htmlTemplate
                .Replace(ApprovedLinkPlaceholder, approvedLink)
                .Replace(PriceCurrencyPlaceholder, request.Value.Currency)
                .Replace(ClientEmailPlaceholder, request.SuggestedByEmployeeEmail)
                .Replace(PriceValuePlaceholder, request.Value.Value.ToString());

            await _emailModule.SendEmailAsync(request.SuggestedByEmployeeEmail, _configuration.Subject, emailAsHtml);
        }
    }
}
