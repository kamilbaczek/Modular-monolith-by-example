namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules;

using Structurizr;

internal static class DrawServicesModule
{
    private const string ApiServices = "Api - Services";

    internal static void ServicesModule(this Container webApplication, Container database, Component bootstrapper)
    {
        var servicesApi = webApplication.AddComponent(ApiServices,
            "Serves API to manage services, categories, services possible values", ".Net Core API");
        bootstrapper.Uses(servicesApi, "");
    }
}
