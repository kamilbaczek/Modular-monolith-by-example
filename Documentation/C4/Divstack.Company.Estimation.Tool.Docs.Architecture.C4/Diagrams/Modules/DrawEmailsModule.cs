namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules;

using Helpers;
using Structurizr;

internal static class DrawEmailsModule
{
    internal static void EmailsModule(this Container webApplication, Component bootstrapper)
    {
        var emails = webApplication.AddComponent("Emails", "Bootstrap emails modules",
            Technologies.DotnetDll);
        bootstrapper.Uses(emails, "");
    }
}
