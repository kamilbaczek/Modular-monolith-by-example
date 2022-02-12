namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules
{
    using Helpers;
    using Structurizr;

    internal static class DrawValuationsModule
    {
        internal static void ValuationModule(this Container webApplication, Component bootstrapper)
        {
            var valuationsApi =
                webApplication.AddComponent("Api - Valuations", "Serves API to estimate services",
                    Technologies.DotnetDll);
            bootstrapper.Uses(valuationsApi, "");
        }
    }
}
