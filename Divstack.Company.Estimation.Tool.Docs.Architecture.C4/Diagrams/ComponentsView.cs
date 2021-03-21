using System.Linq;
using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams
{
    internal static class ComponentsView
    {
        public static void ConfigureComponentsView(this Workspace workspace, Container webApplication, Container database, Person admin, Person customer)
        {
            var bootstraper = webApplication.AddComponent("Bootraper", "compose all components together as one deplyoment unit", "C#");

            var productsApi = webApplication.AddComponent("Api - Products", "Serves API to manage products and categories", ".Net Core API");
            bootstraper.Uses(productsApi, "");

            var productsCore = webApplication.AddComponent("Core - Products", "Provides module skeleton", "C#");
            productsApi.Uses(productsCore, "To managing products and categories");

            var productsDal = webApplication.AddComponent("DAL - Products", "Provides data access layer", "Entity Framework Core");
            productsCore.Uses(productsDal, "");
            productsDal.Uses(database, "");

            var usersApi = webApplication.AddComponent("Api - Users", "Serves API to manage users and authentications", ".Net Core API");
            bootstraper.Uses(usersApi, "");
            var usersInfrastrucutre = webApplication.AddComponent("Infrastructure - Users", "Provides module skeleton", "C#");
            usersApi.Uses(usersInfrastrucutre, "");
            var usersApplication = webApplication.AddComponent("Application - Users", "Run action on bussiness logic (Domain)", "C#");
            usersInfrastrucutre.Uses(usersApplication, "");
            var usersPersistance = webApplication.AddComponent("Persistance - Users", "Database Access", "Entity Framework Core");
            usersInfrastrucutre.Uses(usersPersistance, "");
            var usersDomain = webApplication.AddComponent("Domain - Users", "Bussiness logic", "C#");
            usersApplication.Uses(usersDomain, "");
            usersPersistance.Uses(database, "");
            
            var estimationApi = webApplication.AddComponent("Api - Estimation", "Serves API to estimate services", ".Net Core API");
            bootstraper.Uses(estimationApi, "");
            var estimationInfrastrucutre = webApplication.AddComponent("Infrastructure - Estimation", "Provides module skeleton", "C#");
            estimationApi.Uses(estimationInfrastrucutre, "");
            var estimationApplication = webApplication.AddComponent("Application - Estimation", "Run action on bussiness logic (Domain)", "C#");
            estimationInfrastrucutre.Uses(estimationApplication, "");
            var estimationDomain = webApplication.AddComponent("Domain - Estimation", "Bussiness logic", "C#");
            estimationApplication.Uses(estimationDomain, "");
            estimationInfrastrucutre.Uses(database, "");

            admin.Uses(productsApi, "Manage Products");
            admin.Uses(usersApi, "Manage Users");
            customer.Uses(estimationApi, "Make estimation request");

            var componentView = workspace.Views.CreateComponentView(webApplication, "Components", "Estimation Tool - Component View");
            componentView.AddAllComponents();
            componentView.AddAllPeople();
            componentView.ExternalContainerBoundariesVisible = true;
            componentView.EnableAutomaticLayout();
            componentView.PaperSize = PaperSize.A3_Landscape;
            componentView.Add(database);
        }
    }
}
