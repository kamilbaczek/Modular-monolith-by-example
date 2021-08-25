using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Divstack.Company.Estimation.Tool.Bootstrapper.Configurations
{
    internal static class ConfigurationLoader
    {
        private const string AppSettings = "appsettings";
        internal static void LoadAllConfigurationsFromSolution(this IConfigurationBuilder builder, string envName)
        {
            var baseConfigurations = LoadBaseConfigurations();
            var envConfigurations = LoadEnvConfigurations(envName);

            var allConfigurations = baseConfigurations.Concat(envConfigurations).ToList().AsReadOnly();

            builder.LoadConfigurationFiles(allConfigurations);
        }

        private static void LoadConfigurationFiles(this IConfigurationBuilder builder, ReadOnlyCollection<string> allConfigurations)
        {
            foreach (var configuration in allConfigurations)
            {
                builder.AddJsonFile(configuration);
            }
        }

        private static string[] LoadBaseConfigurations()
        {
            return Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"*-{AppSettings}.json");
        }

        private static string[] LoadEnvConfigurations(string envName)
        {
            var envConfigurations = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, $"*-{AppSettings}.{envName}.json");

            return envConfigurations;
        }
    }
}
