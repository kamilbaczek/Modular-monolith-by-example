using System.Threading.Tasks;
using System.Web;
using Divstack.Company.Estimation.Tool.Emails.Valuations.Proposals.Suggested.Configuration;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Contracts;
using Divstack.Company.Estimation.Tool.Inquiries.Application.Inquiries.Queries.GetClient;
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
        private readonly IEmailSender _emailSender;
        private readonly IInquiriesModule _inquiriesModule;
        private readonly IMailTemplateReader _mailTemplateReader;

        public ValuationProposalSuggestedMailSender(
            ISuggestValuationMailConfiguration configuration,
            IEmailSender emailSender,
            IMailTemplateReader mailTemplateReader,
            IInquiriesModule inquiriesModule)
        {
            _configuration = configuration;
            _emailSender = emailSender;
            _mailTemplateReader = mailTemplateReader;
            _inquiriesModule = inquiriesModule;
        }

        public async Task SendAsync(ValuationProposalSuggestedEmailRequest request)
        {
            var inquiryClientQuery = new GetInquiryClientQuery(request.InquiryId);
            var client = await _inquiriesModule.ExecuteQueryAsync(inquiryClientQuery);

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
                .Replace(FullNamePlaceholder, client.FullName)
                .Replace(DescriptionPlaceholder, request.Description)
                .Replace(PriceCurrencyPlaceholder, request.Currency)
                .Replace(PriceValuePlaceholder, request.Value.ToString());

            _emailSender.Send(client.Email, _configuration.Subject, emailAsHtml);
        }
    }
}