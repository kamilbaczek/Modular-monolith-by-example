using Structurizr;

namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4.Diagrams.Modules
{
    internal static class DrawModules
    {
        internal static void Modules(this Container webApplication, Container database, Component bootstraper)
        {
            webApplication.ServicesModule(database, bootstraper);
            webApplication.ValuationModule(database, bootstraper);
            webApplication.UsersModule(database, bootstraper);
            webApplication.RemindersModule(database, bootstraper);
            webApplication.EmailsModule(bootstraper);
        }
    }
}
