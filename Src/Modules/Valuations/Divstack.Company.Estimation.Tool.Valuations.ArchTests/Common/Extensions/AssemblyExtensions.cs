namespace Divstack.Company.Estimation.Tool.Valuations.ArchTests.Common.Extensions;

internal static class AssemblyExtensions
{
    internal static string[] GetMatchingProjects(this Assembly assembly, string namePart)
    {
        return assembly!
            .GetReferencedAssemblies()
            .Where(assemblyName => assemblyName.Name!
                       .Contains(namePart!, StringComparison.InvariantCultureIgnoreCase))
            .Select(assemblyName => assemblyName.Name)
            .ToArray();
    }
}
