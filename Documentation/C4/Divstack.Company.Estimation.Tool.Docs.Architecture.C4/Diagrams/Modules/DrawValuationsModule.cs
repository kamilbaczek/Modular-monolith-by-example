using Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Helpers;
using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules
{
    internal static class DrawValuationsModule
    {
        internal static void ValuationModule(this Container webApplication, Container database, Component bootstrapper)
        {
            var valuationsApi =
                webApplication.AddComponent("Api - Valuations", "Serves API to estimate services",
                    Technologies.DotnetDll);
            bootstrapper.Uses(valuationsApi, "");
            var valuationsInfrastrucutre =
                webApplication.AddComponent("Infrastructure - Valuations", "Provides module skeleton",
                    Technologies.DotnetDll);
            valuationsApi.Uses(valuationsInfrastrucutre, "");
            var valuationsApplication = webApplication.AddComponent("Application - Valuations",
                "Run action on bussiness logic (Domain)", "C#");
            valuationsInfrastrucutre.Uses(valuationsApplication, "");
            var valuationsDomain =
                webApplication.AddComponent("Domain - Valuations", "Bussiness logic", Technologies.DotnetDll);
            var valuationsIntegrationsEvents = webApplication.AddComponent("Integrations Events - Valuations",
                "Public contracts to exposed to other modules", Technologies.DotnetDll);
            var valuationsInfrastructureTrello = webApplication.AddComponent("Trello - Infrastructure - Valuations",
                "Trello integrations", Technologies.DotnetDll);
            var valuationsInfrastructureSnovIo = webApplication.AddComponent("Snov - Infrastructure - Valuations",
                "Provides client company info like (size, name)", Technologies.DotnetDll);
            var valuationsPersistance = webApplication.AddComponent("Persistance - Valuations",
                "Migrations, DbContexts, Implementation Repositories, Seeders", Technologies.DotnetDll);

            valuationsApplication.Uses(valuationsDomain, "");
            var servicesCore = webApplication.GetComponentWithName(DrawServicesModule.CoreServices);
            valuationsDomain.Uses(servicesCore, "Check requested by client services exists");
            valuationsInfrastrucutre.Uses(valuationsIntegrationsEvents, "Mapping domain events to Integrations Events");
            valuationsInfrastrucutre.Uses(valuationsPersistance, "");
            valuationsPersistance.Uses(database, "");
            valuationsInfrastrucutre.Uses(valuationsInfrastructureTrello, "Register trello module");
            valuationsInfrastrucutre.Uses(valuationsInfrastructureSnovIo, "Register snov.io module");
        }
    }
}
