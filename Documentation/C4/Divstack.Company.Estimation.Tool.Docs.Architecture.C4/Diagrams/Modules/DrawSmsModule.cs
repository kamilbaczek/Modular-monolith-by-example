namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules
{
    using Helpers;
    using Structurizr;

    internal static class DrawSmsModule
    {
        internal static void SmsModule(this Container webApplication, Component bootstrapper)
        {
            var sms = webApplication.AddComponent("Sms", "Bootstrap emails modules",
                Technologies.DotnetDll);
            bootstrapper.Uses(sms, "");
        }
    }
}
