namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules;

using Structurizr;

internal static class DrawUsersModule
{
    internal static void UsersModule(this Container webApplication, Container database, Component bootstrapper)
    {
        var usersApi = webApplication.AddComponent("Api - Users", "Serves API to manage users and authentications",
            ".Net Core API");
        bootstrapper.Uses(usersApi, "");
    }
}
