using OmieSharp.IntegrationTests.ConfigModels;
using System.Reflection;
using System.Text.Json;

namespace OmieSharp.IntegrationTests;

public abstract class BaseTest
{
    private static HttpClient httpClient = new HttpClient();
    private static string? assemblyLocation;

    internal static ConfigurationFile GetConfigurationFile()
    {
        assemblyLocation ??= new System.IO.FileInfo(Assembly.GetEntryAssembly()!.Location).Directory!.FullName;
        string path = System.IO.Path.Combine(assemblyLocation, "config", "main.json");

        if (!System.IO.File.Exists(path))
            throw new FileNotFoundException($"File not found: config\\main.json", path);

        try
        {
            var json = System.IO.File.ReadAllText(path);
            return (JsonSerializer.Deserialize<ConfigurationFile>(json))!;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error reading config file config\\main.json -- {ex.Message}", ex);
        }
    }

    protected static OmieSharpClient GetOmieSharpClient()
    {
        var config = GetConfigurationFile();
        var omieClient = new OmieSharpClient(config.AppKey!, config.AppSecret!, httpClient);
        return omieClient;
    }
}
