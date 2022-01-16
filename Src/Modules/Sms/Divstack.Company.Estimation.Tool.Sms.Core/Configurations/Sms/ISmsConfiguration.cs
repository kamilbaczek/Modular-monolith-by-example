namespace Divstack.Company.Estimation.Tool.Sms.Core.Configurations.Sms;

internal interface ISmsConfiguration
{
    string AccountSid { get; }
    string AuthToken { get; }
}
