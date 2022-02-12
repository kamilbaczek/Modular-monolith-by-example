namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams
{
    using Helpers;
    using Modules;
    using Structurizr;

    internal static class ComponentsView
    {
        public static void ConfigureComponentsView(this Workspace workspace, Container webApplication,
            Container database)
        {
            var bootstrapper = webApplication.AddComponent(
                "Bootstrapper",
                "compose all components together as one deployment unit",
                Technologies.DotnetApi);
            var admin = webApplication.Model.GetPersonWithName("Admin");
            var customer = webApplication.Model.GetPersonWithName("Customer");
            var employee = webApplication.Model.GetPersonWithName("Employee");
            admin.Uses(bootstrapper, "");
            employee.Uses(bootstrapper, "");
            customer.Uses(bootstrapper, "");

            webApplication.Modules(database, bootstrapper);
            var componentView =
                workspace.Views.CreateComponentView(webApplication, "Components", "Estimation Tool - Component View");
            componentView.AddAllComponents();
            componentView.AddAllPeople();
            componentView.ExternalContainerBoundariesVisible = true;
            componentView.PaperSize = PaperSize.A2_Landscape;
            componentView.Add(database);
        }
    }
}
