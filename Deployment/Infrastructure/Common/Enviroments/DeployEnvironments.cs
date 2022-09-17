namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Common.Enviroments;

internal static class DeployEnvironments
{
    internal static IReadOnlyCollection<Enviroment> All => new List<Enviroment>
    {
        Enviroment.Staging,
    };
}
