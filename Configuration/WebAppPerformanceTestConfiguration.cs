namespace Lvp.Kdv.UserActivities.WebApp.PerformanceTests.Configuration
{
    using System.Linq;
    using System.Reflection;

    internal class WebAppPerformanceTestConfiguration
    {
        /// <summary>
        /// Gets or sets the name of the API.
        /// </summary>
        /// <value>
        /// The name of the API.
        /// </value>
        public string ApiName { get; set; }

        /// <summary>
        /// Gets or sets the API version.
        /// </summary>
        /// <value>
        /// The API version.
        /// </value>
        public string ApiVersion { get; set; } = $"v{Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion.Split('.').FirstOrDefault() ?? "1"}";

        /// <summary>
        /// Defaults the name of the API.
        /// </summary>
        /// <param name="systemId">The system identifier.</param>
        /// <returns></returns>
        public static string DefaultApiName() => Assembly.GetEntryAssembly().GetName().Name ?? "Lvp.Kdv.UserActivities.WebApp.PerformanceTests";
    }
}
