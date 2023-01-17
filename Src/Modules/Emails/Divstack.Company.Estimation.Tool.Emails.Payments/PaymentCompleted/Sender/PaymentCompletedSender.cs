namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentCompleted.Sender;

using Common.Extensions;
using Configuration;
using Core;
using Core.Sender.TemplateReader;
using Microsoft.Extensions.Configuration;

internal sealed class PaymentCompletedSender : IPaymentCompletedSender
{
    private const string PaymentIdPlaceholder = "{PaymentId}";
    private readonly IEmailSender _emailSender;
    private readonly IMailTemplateReader _mailTemplateReader;
    private readonly IPaymentCompletedMailConfiguration _paymentCompletedMailConfiguration;

    public PaymentCompletedSender(IMailTemplateReader mailTemplateReader,
        IConfiguration configuration,
        IEmailSender emailSender)
    {
        _mailTemplateReader = mailTemplateReader;
        _paymentCompletedMailConfiguration = new PaymentCompletedMailConfiguration(configuration);
        _emailSender = emailSender;
    }

    public void Send(PaymentCompletedEmailRequest request)
    {
        var htmlTemplate = _mailTemplateReader.Read(_paymentCompletedMailConfiguration.PathToTemplate);
        var emailAsHtml = htmlTemplate
            .ReplaceIgnoreCases(PaymentIdPlaceholder, request.PaymentId);

        _emailSender.Send(request.ClientEmail, _paymentCompletedMailConfiguration.Subject, emailAsHtml);
    }
}
