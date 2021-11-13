namespace Divstack.Company.Estimation.Tool.Emails.Valuations.DeadlineClose.Sender;

using Configuration;
using Modules.Emails.Core.Sender.Contracts;
using Modules.Emails.Core.Sender.TemplateReader;

internal sealed class ValuationCloseToDeadlineMailSender : IValuationCloseToDeadlineMailSender
{
    private const string ValuationIdPlaceholder = "{ValuationId}";
    private const string DaysToDeadlinePlaceholder = "{DaysToDeadline}";

    private readonly IValuationCloseToDeadlineMailConfiguration _configuration;
    private readonly IEmailSender _emailSender;
    private readonly IMailTemplateReader _mailTemplateReader;

    public ValuationCloseToDeadlineMailSender(IValuationCloseToDeadlineMailConfiguration configuration,
        IEmailSender emailSender,
        IMailTemplateReader mailTemplateReader)
    {
        _configuration = configuration;
        _emailSender = emailSender;
        _mailTemplateReader = mailTemplateReader;
    }

    public void Send(ValuationCloseToDeadlineEmailRequest request)
    {
        var htmlTemplate = _mailTemplateReader.Read(_configuration.PathToTemplate);
        var emailAsHtml = htmlTemplate
            .Replace(ValuationIdPlaceholder, request.ValuationId.ToString())
            .Replace(DaysToDeadlinePlaceholder, request.DaysToDeadline.ToString());

        _emailSender.Send(request.EmployeeEmail, _configuration.Subject, emailAsHtml);
    }
}
