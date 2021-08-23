using Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Helpers;
using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules
{
    internal static class DrawUsersModule
    {
        internal static void UsersModule(this Container webApplication, Container database, Component bootstrapper)
        {
            var admin = webApplication.Model.GetPersonWithName("Admin");
            var employee = webApplication.Model.GetPersonWithName("Employee");

            var usersApi = webApplication.AddComponent("Api - Users", "Serves API to manage users and authentications",
                ".Net Core API");
            bootstrapper.Uses(usersApi, "");
            var usersInfrastrucutre =
                webApplication.AddComponent("Infrastructure - Users", "Provides module skeleton", Technologies.DotnetDll);
            usersApi.Uses(usersInfrastrucutre, "");
            var usersApplication =
                webApplication.AddComponent("Application - Users", "Run action on bussiness logic (Domain)", Technologies.DotnetDll);
            usersInfrastrucutre.Uses(usersApplication, "");
            var usersPersistance =
                webApplication.AddComponent("Persistance - Users", "Database Access", "Entity Framework Core");
            usersInfrastrucutre.Uses(usersPersistance, "");
            var usersDomain = webApplication.AddComponent("Domain - Users", "Bussiness logic", Technologies.DotnetDll);
            usersApplication.Uses(usersDomain, "");
            usersPersistance.Uses(database, "");

            admin.Uses(usersApi, "Manage Users");
            employee.Uses(usersApi, "Sign In/Sign out");
        }
    }
}
