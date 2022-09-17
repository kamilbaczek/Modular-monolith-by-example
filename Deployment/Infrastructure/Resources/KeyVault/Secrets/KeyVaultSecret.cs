namespace Divstack.Estimation.Tool.Deployment.Infrastructure.Resources.KeyVault.Secrets;

internal record struct KeyVaultSecret(string Name, IReadOnlyCollection<SecuredAppConfigKey> SecuredAppConfigKeys);
