namespace Divstack.Company.Estimation.Tool.Docs.Architecture.C4
{
    using Configuration;
    using Diagrams;
    using Structurizr;
    using Structurizr.Api;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new StructurizrClient(StructurizrAccountConfiguration.ApiKey,
                StructurizrAccountConfiguration.ApiSecret);

            var workspace = new Workspace("Divstack Estimation Tool", "This is a model of estimation system.");
            workspace.ConfigureSystemContextView();

            client.PutWorkspace(StructurizrAccountConfiguration.WorkspaceId, workspace);
        }
    }
}
