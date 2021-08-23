using Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Helpers;
using Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules;
using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams
{
    internal static class ComponentsView
    {
        public static void ConfigureComponentsView(this Workspace workspace, Container webApplication,
            Container database, Person admin, Person customer)
        {
            var boostrapper = webApplication.AddComponent(
                "Bootstrapper",
                "compose all components together as one deployment unit",
                Technologies.DotnetApi);

            webApplication.Modules(database, boostrapper);
            var componentView =
                workspace.Views.CreateComponentView(webApplication, "Components", "Estimation Tool - Component View");
            componentView.AddAllComponents();
            componentView.AddAllPeople();
            componentView.ExternalContainerBoundariesVisible = true;
            componentView.EnableAutomaticLayout();
            componentView.PaperSize = PaperSize.A3_Landscape;
            componentView.Add(database);
        }
    }
}
