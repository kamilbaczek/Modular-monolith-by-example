namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules;

using Helpers;
using Structurizr;

internal static class DrawRemindersModule
{
    internal static void RemindersModule(this Container webApplication, Container database, Component bootstrapper)
    {
        var reminders =
            webApplication.AddComponent("Reminders", "Reminders bootstrapper", Technologies.DotnetDll);

        bootstrapper.Uses(reminders, "");
    }
}
