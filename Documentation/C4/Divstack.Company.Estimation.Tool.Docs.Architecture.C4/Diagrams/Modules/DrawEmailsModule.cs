using Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Helpers;
using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules
{
    internal static class DrawEmailsModule
    {
        internal static void EmailsModule(this Container webApplication, Component bootstrapper)
        {
            var emails = webApplication.AddComponent("Emails", "Bootstrap emails modules",
                Technologies.DotnetDll);
            bootstrapper.Uses(emails, "");
            var emailsCore =
                webApplication.AddComponent("Emails - Core", "Sending email abstractions", Technologies.DotnetDll);
            emails.Uses(emailsCore, "");
            var emailsValuations =
                webApplication.AddComponent("Emails - Valuations", "Emails module for valuations", Technologies.DotnetDll);
            emails.Uses(emailsCore, "");
            emailsValuations.Uses(emailsCore, "Use abstractions");
            var emailsUsers =
                webApplication.AddComponent("Emails - Users", "Emails module for users", Technologies.DotnetDll);
            emailsUsers.Uses(emailsCore, "Use abstractions");
        }
    }
}
