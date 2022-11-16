namespace ABCsoft.CatFactNinja.WebAPI.TestLearningTask.Configuration
{
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Globalization;

    public class TestSettings
    {

        private readonly IConfiguration Configuration;
        
        


        ///<inheritdoc/>
        public string HealthCheckUrl { get; private set; }

        ///<inheritdoc/>
        public string WebAppUrl { get; private set; }

        ///<inheritdoc/>
        public string CookiePath { get; private set; }
        ///<inheritdoc/>
        public string CookieC1 { get; private set; }
        ///<inheritdoc/>
        public string CookieC2 { get; private set; }
        ///<inheritdoc/>
        public string CookieC3 { get; private set; }
        ///<inheritdoc/>
        public string CookieDomain { get; private set; }

        #region MyVariables

        
        
        public string WebApiUrl { get; init; }
        public string PathFact { get; init; }
        public string PathFacts { get; init; }
        public string PathBreeds { get; init; }
        
        public string MaxLenghtParameter { get; init; }

        #endregion

        public TestSettings()
        {
            Configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            HealthCheckUrl = GetConfigurationParameter("HealthCheckUrl", required: true);
            WebAppUrl = GetConfigurationParameter("WebAppUrl", required: true);
            CookiePath = GetConfigurationParameter("CookiePath", required: true);
            CookieDomain = GetConfigurationParameter("CookieDomain", required: true);
            CookieC1 = GetConfigurationParameter("CookieC1", required: true);
            CookieC2 = GetConfigurationParameter("CookieC2", required: true);
            CookieC3 = GetConfigurationParameter("CookieC3", required: true);

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
}
