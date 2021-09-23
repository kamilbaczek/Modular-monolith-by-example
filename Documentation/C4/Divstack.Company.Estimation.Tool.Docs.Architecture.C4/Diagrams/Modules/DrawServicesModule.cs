using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules
{
    internal static class DrawServicesModule
    {
        private const string ApiServices = "Api - Services";
        internal const string CoreServices = "Core - Services";

        internal static void ServicesModule(this Container webApplication, Container database, Component bootstrapper)
        {
            var servicesApi = webApplication.AddComponent(ApiServices,
                "Serves API to manage services, categories, services possible values", ".Net Core API");
            bootstrapper.Uses(servicesApi, "");

            var servicesCore = webApplication.AddComponent(CoreServices, "Provides module skeleton", "C#");
            servicesApi.Uses(servicesCore, "To managing services and categories");

            var servicesDal = webApplication.AddComponent("DAL - Services", "Provides data access layer",
                "Entity Framework Core");
            servicesCore.Uses(servicesDal, "");
            servicesDal.Uses(database, "");
        }
    }
}