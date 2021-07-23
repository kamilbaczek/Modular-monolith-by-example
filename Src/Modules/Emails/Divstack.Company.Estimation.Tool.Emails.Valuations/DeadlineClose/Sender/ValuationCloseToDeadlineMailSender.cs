using System.Threading.Tasks;
using Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Configuration;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.Contracts;
using Divstack.Company.Estimation.Tool.Modules.Emails.Core.Sender.TemplateReader;

namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Sender
{
    internal sealed class ValuationCloseToDeadlineMailSender : IValuationCloseToDeadlineMailSender
    {
        private const string ValuationIdPlaceholder = "{ValuationId}";
        private const string DaysToDeadlinePlaceholder = "{DaysToDeadline}";

        private readonly IValuationCloseToDeadlineMailConfiguration _configuration;
        private readonly IEmailModule _emailModule;
        private readonly IMailTemplateReader _mailTemplateReader;

        public ValuationCloseToDeadlineMailSender(IValuationCloseToDeadlineMailConfiguration configuration,
            IEmailModule emailModule,
            IMailTemplateReader mailTemplateReader)
        {
            _configuration = configuration;
            _emailModule = emailModule;
            _mailTemplateReader = mailTemplateReader;
        }

        public async Task SendEmailAsync(ValuationCloseToDeadlineEmailRequest request)
        {
            var htmlTemplate = _mailTemplateReader.Read(_configuration.PathToTemplate);
            var emailAsHtml = htmlTemplate
                .Replace(ValuationIdPlaceholder, request.ValuationId.ToString())
                .Replace(DaysToDeadlinePlaceholder, request.DaysToDeadline.ToString());

            await _emailModule.SendEmailAsync(request.EmployeeEmail, _configuration.Subject, emailAsHtml);
        }
    }
}
