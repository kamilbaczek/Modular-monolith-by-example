using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams
{
    internal static class ContainersView
    {
        public static void ConfigureContainersView(this Workspace workspace, SoftwareSystem softwareSystem, Person customer, Person admin)
        {
            var webApplication = softwareSystem.AddContainer("Web Application", "Provides all of the estimation functionality to customers.", ".NET Core");
            var mobileApp = softwareSystem.AddContainer("Mobile", "", "Xamarin");
            var database = softwareSystem.AddContainer("Database", "Stores interesting data.", "MSSQL");
            var clientApp = softwareSystem.AddContainer("Client App", "Display UI", "Nuxt.JS");
            var elasticSearch = softwareSystem.AddContainer("ElasticSearch", "Logs, metrics", "ElasticSearch");

            customer.Uses(clientApp, "HTTPS");
            admin.Uses(clientApp, "HTTPS");

            customer.Uses(mobileApp, "View");
            clientApp.Uses(webApplication, "Execute commands and queries", "REST");
            webApplication.Uses(database, "Writes to", "EF Core");
            webApplication.Uses(database, "Read from", "Dapper");
            webApplication.Uses(elasticSearch, "Save logs, metrics", "REST");


            var containerView = workspace.Views.CreateContainerView(softwareSystem, "Containers", "The container diagram for the Estimation Tool.");

            containerView.AddAllPeople();
            containerView.AddAllContainers();
            workspace.ConfigureComponentsView(webApplication, database, admin, customer);
        }
    }
}
