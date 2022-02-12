namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams
{
    using Helpers;
    using Structurizr;

    internal static class ContainersView
    {
        public static void ConfigureContainersView(this Workspace workspace, SoftwareSystem softwareSystem)
        {
            var customer = workspace.Model.GetPersonWithName("Customer");
            var admin = workspace.Model.GetPersonWithName("Admin");
            var employee = workspace.Model.GetPersonWithName("Employee");

            var webApplication = softwareSystem.AddContainer("Web Application",
                "Provides all of the estimation functionality to customers.", Technologies.DotnetApi);
            var mysql = softwareSystem.AddContainer("Database", "Stores interesting data.", "MySQL");
            var mongoDb = softwareSystem.AddContainer("Database", "Stores interesting data.", "mongoDb");
            var clientApp = softwareSystem.AddContainer("Client App", "Display UI", "Vue.js");
            var elasticSearch = softwareSystem.AddContainer("ElasticSearch", "Logs, metrics", "ElasticSearch");
            var hangfire = softwareSystem.AddContainer("Hangfire", "Background Processing", "Hangfire .Net");

            customer.Uses(clientApp, "HTTPS");
            admin.Uses(clientApp, "HTTPS");
            employee.Uses(clientApp, "HTTPS");

            clientApp.Uses(webApplication, "Execute commands and queries", "REST");
            webApplication.Uses(mysql, "Writes to", "EF Core");
            webApplication.Uses(mysql, "Read from", "Dapper");
            webApplication.Uses(elasticSearch, "Save logs, metrics", "REST");
            webApplication.Uses(hangfire, "Running recurring jobs, running functions out of process");

            var containerView = workspace.Views.CreateContainerView(softwareSystem, "Containers",
                "The container diagram for the Estimation Tool.");

            containerView.EnableAutomaticLayout();
            containerView.AddAllPeople();
            containerView.AddAllContainers();
            workspace.ConfigureComponentsView(webApplication, mysql);
            containerView.EnableAutomaticLayout();
        }
    }
}
