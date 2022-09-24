using ConfigurationStore = Pulumi.AzureNative.AppConfiguration.ConfigurationStore;

namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.AppConfiguration;

using Pulumi.Azure.Authorization;

internal record struct ConfigurationStoreCreationResult(ConfigurationStore ConfigurationStore, Assignment Assigment);
