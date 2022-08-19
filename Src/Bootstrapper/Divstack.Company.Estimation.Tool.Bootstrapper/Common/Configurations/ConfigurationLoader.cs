﻿namespace Divstack.Company.Estimation.Tool.Bootstrapper.Common.Configurations;

using System.Collections.ObjectModel;

internal static class ConfigurationLoader
{
    private const string AppSettings = "appsettings";

    internal static void AddAllConfigurationsFromSolution(this IConfigurationBuilder builder, string envName)
    {
        var loadDefaultConfigurations = LoadDefaultConfigurations();
        var envConfigurations = LoadEnvConfigurations(envName);

        var allConfigurations = loadDefaultConfigurations.Concat(envConfigurations).ToList().AsReadOnly();

        builder.LoadConfigurationFiles(allConfigurations);
    }

    private static void LoadConfigurationFiles(this IConfigurationBuilder builder,
        ReadOnlyCollection<string> allConfigurations)
    {
        foreach (var configuration in allConfigurations)
        {
            builder.AddJsonFile(configuration);
        }
    }

    private static string[] LoadDefaultConfigurations()
    {
        return Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"*-{AppSettings}.json");
    }

    private static string[] LoadEnvConfigurations(string envName)
    {
        var envConfigurations =
            Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"*-{AppSettings}.{envName}.json");

        return envConfigurations;
    }
}
