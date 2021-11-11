using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams
{
    internal static class SystemContextView
    {
        public static void ConfigureSystemContextView(this Workspace workspace)
        {
            var model = workspace.Model;
            var customer = model.AddPerson("Customer", "A customer of estimate system.");
            var employee = model.AddPerson("Employee", "A person responsible for make estimation.");
            var admin = model.AddPerson("Admin", "A person responsible for system infrastructure.");

            var estimationTool = model.AddSoftwareSystem("Divstack Estimation Tool", "");

            var trello = model.AddSoftwareSystem(Location.External, "Trello",
                "Trello is a collaboration tool that organizes your projects into boards. In one glance, Trello tells you what's being worked on, who's working on what, and where something is in a process.");
            var snovio = model.AddSoftwareSystem(Location.External, "Snov.io",
                "Snov.io tool to generate leads");
            estimationTool.Uses(trello, "Create boards and tasks for employee");
            estimationTool.Uses(snovio, "Get informations about client company");

            customer.Uses(estimationTool, "To request estimate of service/approve/reject");
            employee.Uses(estimationTool, "To make a service valuation/cancel/complete");
            admin.Uses(estimationTool, "Manage system configuration, users, services");

            var viewSet = workspace.Views;
            var contextView = viewSet.CreateSystemContextView(estimationTool, "SystemContext",
                "Divstack Estimate System Context View.");
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();

            var styles = viewSet.Configuration.Styles;
            styles.Add(new ElementStyle(Tags.SoftwareSystem) { Background = "#1168bd", Color = "#ffffff" });
            styles.Add(new ElementStyle(Tags.Person) { Background = "#08427b", Color = "#ffffff", Shape = Shape.Person });

            workspace.ConfigureContainersView(estimationTool);
            contextView.EnableAutomaticLayout();
        }
    }
}
