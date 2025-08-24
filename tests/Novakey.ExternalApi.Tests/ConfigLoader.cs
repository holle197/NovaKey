using Microsoft.Extensions.Configuration;

namespace Novakey.ExternalApi.Tests;

internal static class ConfigLoader
{
    internal static IConfiguration LoadFromSolutionRoot()
    {
        return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }
}
