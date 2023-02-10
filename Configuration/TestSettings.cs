namespace ABCsoft.CatFactNinja.WebAPI.TestLearningTask.Configuration;

using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;

public class TestSettings
{

    private readonly IConfiguration Configuration;

    #region MyVariables
    public string WebApiUrl { get; }
    public string PathFact { get; }
    public string PathFacts { get; }
    public string PathBreeds { get; }
        
    public string MaxLenghtParameter { get; init; }

    #endregion

    public TestSettings()
    {
        Configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        WebApiUrl = GetConfigurationParameter("WebApiUrl", required: true);
        PathFact = GetConfigurationParameter("PathFact", required: true);
        PathFacts = GetConfigurationParameter("PathFacts", required: true);
        PathBreeds = GetConfigurationParameter("PathBreeds", required: true);

        MaxLenghtParameter = GetConfigurationParameter("MaxLenghtParameter", required: true);
    }

    /// <summary>
    /// Gets the configuration parameter.
    /// </summary>
    /// <param name="parameterName">Name (key) of the parameter.</param>
    /// <param name="required">if set to <c>true</c> [required].</param>
    /// <returns>Parameter value or error.</returns>
    public string GetConfigurationParameter(string parameterName, bool required)
    {
        if (string.IsNullOrWhiteSpace(parameterName))
        {
            throw new ArgumentNullException(nameof(parameterName));
        }

        string value = Configuration[parameterName];

        if (!required && value == null)
        {
            return null;
        }

        if (required && string.IsNullOrWhiteSpace(value))
        {
            throw new Exception(string.Format(CultureInfo.InvariantCulture, "Invalid resource or no resource in settings file: ", parameterName));
        }

        return value;
    }
}
