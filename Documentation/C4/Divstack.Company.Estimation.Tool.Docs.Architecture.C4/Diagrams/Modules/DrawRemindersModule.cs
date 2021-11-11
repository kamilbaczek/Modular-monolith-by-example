using Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Helpers;
using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules
{
    internal static class DrawRemindersModule
    {
        internal static void RemindersModule(this Container webApplication, Container database, Component bootstrapper)
        {
            var reminders =
                webApplication.AddComponent("Reminders", "Reminders bootstrapper", Technologies.DotnetDll);
            var remindersValuations =
                webApplication.AddComponent("Reminders - Valuations",
                    "Reminders Scheduler, Reminder Events for Valuations Module", Technologies.DotnetDll);
            reminders.Uses(remindersValuations, "Register SubModule");

            bootstrapper.Uses(reminders, "");
        }
    }
}
