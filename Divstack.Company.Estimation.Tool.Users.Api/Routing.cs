using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Divstack.Company.Estimation.Tool.Products.IntegrationsTests")]

namespace Divstack.Company.Estimation.Tool.Users.Api
{
    internal static class Routing
    {
        private const string Host = "https://localhost/";
        private const string ModuleBase = "api/users-module";

        internal static class Authentication
        {
            private const string Controller = Host + ModuleBase + "/" + nameof(Authentication) + "/";

            internal const string SignIn = Controller;
        }
    }
}