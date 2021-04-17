
using System;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Divstack.Company.Estimation.Tool.Services.IntegrationsTests")]
namespace Divstack.Company.Estimation.Tool.Services.Api
{
    internal static class Routing
    {
        private const string Host = "https://localhost/";
        internal const string ModuleBase = "api/services-module";

        internal static class Services
        {
            private const string ServicesController = Host + ModuleBase + "/" + nameof(Services) +"/" ;

            internal const string GetAll = ServicesController;
            internal const string Create = ServicesController;
            internal static string Delete(Guid id) => ServicesController + id;

            internal static class Attributes
            {
                private const string AttributesController = ServicesController + "Attributes";
                internal const string Create = AttributesController;
                internal const string Delete = AttributesController;
            }

            internal static class Categories
            {
                private const string Controller = ServicesController ;

                internal const string GetAll = Controller + nameof(GetAll);
                internal const string Create = Controller + nameof(Create);
            }
        }
    }
}
