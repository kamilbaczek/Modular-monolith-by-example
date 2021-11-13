namespace Divstack.Company.Estimation.Tool.Emails.Payments.PaymentInitialized.Sender;

using Configuration;
using Modules.Emails.Core.Sender.Contracts;
using Modules.Emails.Core.Sender.TemplateReader;

internal sealed class PaymentInitializedSender : IPaymentInitializedSender
{
    private const string InquiryIdPlaceholder = "{InquiryId}";
    private const string PaymentIdPlaceholder = "{PaymentId}";
    private const string AmountToPayPlaceholder = "{AmountToPay}";
    private const string ClientFullNamePlaceholder = "{ClientFullName}";
    private const string PaymentLinkPlaceholder = "{PaymentLink}";
    private readonly IPaymentInitializedMailConfiguration _configuration;
    private readonly IEmailSender _emailSender;
    private readonly IMailTemplateReader _mailTemplateReader;

    public PaymentInitializedSender(IMailTemplateReader mailTemplateReader,
        IPaymentInitializedMailConfiguration configuration,
        IEmailSender emailSender)
    {
        _mailTemplateReader = mailTemplateReader;
        _configuration = configuration;
        _emailSender = emailSender;
    }

    public void Send(PaymentInitializedEmailRequest request)
    {
        var htmlTemplate = _mailTemplateReader.Read(_configuration.PathToTemplate);
        var paymentLink = _configuration.PaymentUrl.Replace(PaymentIdPlaceholder, request.PaymentId.ToString());
        var emailAsHtml = htmlTemplate
            .Replace(InquiryIdPlaceholder, request.PaymentId.ToString())
            .Replace(AmountToPayPlaceholder, request.AmountToPay)
            .Replace(ClientFullNamePlaceholder, request.ClientFullName)
            .Replace(PaymentLinkPlaceholder, paymentLink);

        _emailSender.Send(request.ClientEmail, _configuration.Subject, emailAsHtml);
    }
}
