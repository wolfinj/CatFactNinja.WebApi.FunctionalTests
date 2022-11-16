using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using ABCsoft.CatFactNinja.WebAPI.TestLearningTask.Configuration;

namespace ABCsoft.CatFactNinja.WebAPI.TestLearningTask
{
    
    public class InitializationTests : TestSettings
    {
        // [Test, Description("Check Health status of WebApp"), Category("Complete")]
        // [TestCase("Healthy")]
        // public async Task HealthCheckSearchApi(string status)
        // {
        //     var client = new RestClient();
        //     client.CookieContainer.Add(new Cookie(".AspNetCore.Cookies", "chunks-3", CookiePath, CookieDomain));
        //     client.CookieContainer.Add(new Cookie(".AspNetCore.CookiesC1", CookieC1, CookiePath, CookieDomain));
        //     client.CookieContainer.Add(new Cookie(".AspNetCore.CookiesC2", CookieC2, CookiePath, CookieDomain));
        //     client.CookieContainer.Add(new Cookie(".AspNetCore.CookiesC3", CookieC3, CookiePath, CookieDomain));
        //
        //     string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
        //
        //     var request = new RestRequest(WebAppUrl, Method.Get);
        //     request.AddHeader("User-Agent", userAgent);
        //
        //     Task<RestResponse> t = client.ExecuteAsync(request);
        //     var restResponse = await t;
        //     var respCont = restResponse.Content;
        //     Assert.IsNotNull(respCont);
        //     Assert.IsTrue(restResponse.IsSuccessStatusCode);
        // }

        private TestSettings Settings;
        
        [SetUp]
        public async Task Setup()
        {
            Settings = new TestSettings();
        }
    }
}
