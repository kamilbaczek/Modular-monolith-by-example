namespace Csl.Cmp.SimInventory.Arch.Tests.Common.Extensions;

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
