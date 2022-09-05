namespace Divstack.Estimation.Tool.Deplyoment.Infrastructure.Resources.AppService;

using Pulumi;
using Pulumi.Azure.AppInsights;
using Pulumi.Azure.AppService;
using Pulumi.Azure.AppService.Inputs;
using Pulumi.AzureNative.Resources;

internal static class AppServiceCreator
{
    internal static AppService Create(string environment, Insights insights, Config config, ResourceGroup resourceGroup, Plan plan)
    {
        return new($"svc-{environment}-api", new AppServiceArgs
        {
            AppServicePlanId = plan.Id,
            AppSettings =
            {
                {
                    "APPINSIGHTS_INSTRUMENTATIONKEY", insights.InstrumentationKey
                },
                {
                    "ASPNETCORE_ENVIRONMENT", environment
                },
                {
                    "ApplicationInsightsAgent_EXTENSION_VERSION", "~3"
                },
                {
                    "DOCKER_REGISTRY_SERVER_PASSWORD", config.RequireSecret("DOCKER_REGISTRY_SERVER_PASSWORD")
                },
                {
                    "DOCKER_REGISTRY_SERVER_URL", "https://index.docker.io/v1"
                },
                {
                    "DOCKER_REGISTRY_SERVER_USERNAME", config.RequireSecret("DOCKER_REGISTRY_SERVER_USERNAME")
                },
                {
                    "WEBSITES_ENABLE_APP_SERVICE_STORAGE", "false"
                },
                {
                    "WEBSITE_HEALTHCHECK_MAXPINGFAILURES", "3"
                },
                {
                    "XDT_MicrosoftApplicationInsights_Mode", "default"
                }
            },
            AuthSettings = new AppServiceAuthSettingsArgs
            {
                Enabled = false,
                TokenRefreshExtensionHours = 0
            },
            ClientCertMode = "Required",
            Location = resourceGroup.Location,
            Logs = new AppServiceLogsArgs
            {
                HttpLogs = new AppServiceLogsHttpLogsArgs
                {
                    FileSystem = new AppServiceLogsHttpLogsFileSystemArgs
                    {
                        RetentionInDays = 0,
                        RetentionInMb = 35
                    }
                }
            },
            ResourceGroupName = resourceGroup.Name,
            SiteConfig = new AppServiceSiteConfigArgs
            {
                DefaultDocuments = new[]
                {
                    "Default.htm", "Default.html", "Default.asp", "index.htm", "index.html", "iisstart.htm", "default.aspx", "index.php", "hostingstart.html"
                },
                FtpsState = "AllAllowed",
                HealthCheckPath = "/healthcheck",
                ManagedPipelineMode = "Integrated",
                MinTlsVersion = "1.2",
                NumberOfWorkers = 1,
                RemoteDebuggingVersion = "VS2019"
            },
            Tags =
            {
                {
                    nameof(environment), environment
                }
            }
        });
    }
}
