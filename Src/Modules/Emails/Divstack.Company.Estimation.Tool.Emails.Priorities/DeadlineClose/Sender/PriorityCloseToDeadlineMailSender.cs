namespace Divstack.Company.Estimation.Tool.Emails.Priorities.DeadlineClose.Sender;

using Configuration;
using Core;
using Core.Sender.TemplateReader;

internal sealed class PriorityCloseToDeadlineMailSender : IPriorityCloseToDeadlineMailSender
{
    private const string ValuationIdPlaceholder = "{ValuationId}";
    private const string DaysToDeadlinePlaceholder = "{DaysToDeadline}";

    private readonly IPriorityCloseToDeadlineMailConfiguration _configuration;
    private readonly IEmailSender _emailSender;
    private readonly IMailTemplateReader _mailTemplateReader;

    public PriorityCloseToDeadlineMailSender(IPriorityCloseToDeadlineMailConfiguration configuration,
        IEmailSender emailSender,
        IMailTemplateReader mailTemplateReader)
    {
        _configuration = configuration;
        _emailSender = emailSender;
        _mailTemplateReader = mailTemplateReader;
    }

    public void Send(PriorityCloseToDeadlineEmailRequest request)
    {
        var htmlTemplate = _mailTemplateReader.Read(_configuration.PathToTemplate);
        var emailAsHtml = htmlTemplate
            .Replace(ValuationIdPlaceholder, request.ValuationId.ToString())
            .Replace(DaysToDeadlinePlaceholder, request.DaysToDeadline.ToString());

        _emailSender.Send(request.EmployeeEmail, _configuration.Subject, emailAsHtml);
    }
}
