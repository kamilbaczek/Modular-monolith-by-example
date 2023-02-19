namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;

internal static class AppConfigurationKeys
{
    internal static IDictionary<string, string> NotSecuredKeys => new Dictionary<string, string>
    {
        {
            "Logging:LogLevel:Default", "Debug"
        },
        {
            "Logging:LogLevel:Microsoft", "Debug"
        },
        {
            "Logging:LogLevel:Microsoft.Hosting.Lifetime", "Debug"
        },
        {
            "Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware", "Debug"
        },
        {
            "ApplicationInsights:LogLevel:Default", "Debug"
        },
        {
            "ApplicationInsights:LogLevel:Microsoft", "Debug"
        },
        {
            "ApplicationInsights:LogLevel:Microsoft.AspNetCore.HttpLogging.HttpLoggingMiddleware", "Debug"
        },
        {
            "DateFormat", "Debug"
        },
        {
            "AllowedHosts", "*"
        },
        {
            "Priority:Deadline:WorksDaysToDeadlineFromNow", "3"
        },
        {
            "TokenConfiguration:Issuer", "localhost:5001"
        },
        {
            "TokenConfiguration:Audience", "DeveloperAudience"
        },
        {
            "TokenConfiguration:AccessExpirationInMinutes", "10000000"
        },
        {
            "TokenConfiguration:RefreshExpirationInMinutes", "100000"
        },
        {
            "TokenConfiguration:LinksExpirationInMinutes", "15"
        },
        {
            "Users:PasswordExpirationFrequency", "30"
        },
        {
            "AdminAccount:UserName", "admin@divstack.pl"
        },
        {
            "AdminAccount:Email", "admin@divstack.pl"
        },
        {
            "AdminAccount:Password", "3wsx$EDC5rfvtest4"
        },
        {
            "AdminAccount:Init", "true"
        },
        {
            "SuggestValuationMailConfiguration:Subject", "ProposalSuggest"
        },
        {
            "SuggestValuationMailConfiguration:PathToTemplate", "Proposals/Templates/valuation_proposal_suggested_mail.html"
        },
        {
            "SuggestValuationMailConfiguration:RejectProposalLink", "http://localhost:8080/valuations/{ValuationId}/proposals/{ProposalId}/reject"
        },
        {
            "SuggestValuationMailConfiguration:AcceptProposalLink", "http://localhost:8080/valuations/{ProposalId}"
        },
        {
            "ValuationProposalApprovedMailConfiguration:Subject", "Proposal Approved"
        },
        {
            "ValuationProposalApprovedMailConfiguration:PathToTemplate", "Proposals/Templates/valuation_proposal_approved_mail.html"
        },
        {
            "ValuationProposalApprovedMailConfiguration:ApprovedProposalLink", "http://localhost:8080/valuations/{ProposalId}"
        },
        {
            "Mail:ServerAddress", "smtp.mailtrap.io"
        },
        {
            "Mail:ServerPort", "25"
        },
        {
            "Mail:MailFrom", "no-reply@estimation-tool.com"
        },
        {
            "Mail:DisableSsl", "false"
        },
        {
            "Mail:ServerLogin", ""
        },
        {
            "Mail:ServerPassword", ""
        },
        {
            "PaymentInitializedMailConfiguration:Subject", "Payment"
        },
        {
            "PaymentInitializedMailConfiguration:PaymentUrl", "http://localhost:8080/payments/pay/{PaymentId}"
        },
        {
            "PaymentInitializedMailConfiguration:PathToTemplate", "PaymentInitialized/Templates/payment_initialized.html"
        },
        {
            "PaymentCompletedMailConfiguration:Subject", "Payment Completed"
        },
        {
            "PaymentCompletedMailConfiguration:PathToTemplate", "PaymentInitialized/Templates/payment_completed.html"
        },
        {
            "PriorityCloseToDeadlineMailConfiguration:Subject", "Priority close to Deadline !!!"
        },
        {
            "PriorityCloseToDeadlineMailConfiguration:PathToTemplate", "DeadlineClose/Templates/priority_close_to_deadline_mail.html"
        },
        {
            "Reminders:Priority:DaysBeforeDeadline", "2"
        },
        {
            "Trello:BoardId", "0fj56AI6"
        },
        {
            "Cors:Origin", "http://localhost:8080"
        },
        {
            "WebSockets:AllowedOrigin", "http://localhost:8080"
        },
        {
            "EventBus:Storage:DatabaseName", "EstimationTool"
        }
    };

    internal static IDictionary<string, bool> FeatureFlags => new Dictionary<string, bool>
    {
        {
            "ServicesModule", true
        },
        {
            "ValuationModule", true
        },
        {
            "InquiriesModule", true
        },
        {
            "UsersModule", true
        },
        {
            "RemindersModule", true
        },
        {
            "EmailsModule", true
        },
        {
            "PrioritiesModule", true
        },
        {
            "SmsModule", false
        },
        {
            "TrelloModule", true
        },
        {
            "EventsModule", true
        },
        {
            "HangfireModule", true
        }
    };
}
