namespace Divstack.Company.Estimation.Tool.Shared.Infrastructure.Azure.Configuration.Exception;

internal sealed class EnvironmentNameNotFoundException : InvalidOperationException
{
    private new const string Message = "Environment variable 'ASPNETCORE_ENVIRONMENT' value. Cannot be found";
    public EnvironmentNameNotFoundException() : base(Message)
    {
    }
}
