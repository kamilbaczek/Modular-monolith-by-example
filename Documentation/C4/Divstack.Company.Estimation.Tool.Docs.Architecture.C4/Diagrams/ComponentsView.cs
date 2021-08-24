using Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Helpers;
using Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules;
using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams
{
    internal static class ComponentsView
    {
        public static void ConfigureComponentsView(this Workspace workspace, Container webApplication,
            Container database)
        {
            var boostrapper = webApplication.AddComponent(
                "Bootstrapper",
                "compose all components together as one deployment unit",
                Technologies.DotnetApi);
            var admin = webApplication.Model.GetPersonWithName("Admin");
            var customer = webApplication.Model.GetPersonWithName("Customer");
            var employee = webApplication.Model.GetPersonWithName("Employee");
            admin.Uses(boostrapper, "");
            employee.Uses(boostrapper, "");
            customer.Uses(boostrapper, "");

            webApplication.Modules(database, boostrapper);
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
