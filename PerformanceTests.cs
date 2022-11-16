// using NUnit.Framework;
// using RestSharp;
// using System;
// using System.Diagnostics;
// using System.Net;
// using System.Threading.Tasks;
// using ABCsoft.CatFactNinja.WebAPI.TestLearningTask.Configuration;
// using ABCsoft.CatFactNinja.WebAPI.TestLearningTask.Helper;
//
// namespace ABCsoft.CatFactNinja.WebAPI.TestLearningTask
// {
//     public class PerformanceTests : TestSettings
//     {
//         [Test, Description("WebApp call"), Category("Complete")]
//         [TestCase(100)]
//         [TestCase(500)]
//         [TestCase(1000)]
//         public async Task WebAppCallTest(int totalCount)
//         {
//             Stopwatch timer = new Stopwatch();
//             timer.Start();
//             double lastResponseTime = 0;
//             double[] responseTimes = new double[totalCount];
//             long totalDataReceived = 0;
//             int successResponses = 0;
//             int logInResponses = 0;
//             int logOutResponses = 0;
//
//             for (int i = 1; i <= totalCount; i++)
//             {
//                 var client = new RestClient();
//                 client.CookieContainer.Add(new Cookie(".AspNetCore.Cookies", "chunks-3", CookiePath, CookieDomain));
//                 client.CookieContainer.Add(new Cookie(".AspNetCore.CookiesC1", CookieC1, CookiePath, CookieDomain));
//                 client.CookieContainer.Add(new Cookie(".AspNetCore.CookiesC2", CookieC2, CookiePath, CookieDomain));
//                 client.CookieContainer.Add(new Cookie(".AspNetCore.CookiesC3", CookieC3, CookiePath, CookieDomain));
//
//                 string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.0.0 Safari/537.36";
//
//                 var request = new RestRequest(WebAppUrl, Method.Get);
//                 request.AddHeader("User-Agent", userAgent);
//
//                 Task<RestResponse> t = client.ExecuteAsync(request);
//                 var response = await t;
//                 totalDataReceived += response.ContentLength.Value;
//                 responseTimes[i - 1] = timer.Elapsed.TotalSeconds - lastResponseTime;
//                 lastResponseTime += responseTimes[i - 1];
//                 if (response.StatusCode == HttpStatusCode.OK)
//                 {
//                     successResponses++;
//                 }
//
//                 /*if (response.Content.Contains("Vienot�s pieteik�an�s modulis"))
//                 {
//                     logOutResponses++;
//                 }*/
//                 if (response.Content.Contains("user-card__username js--username") || response.Content.Contains("user - card__username js--username") || response.Content.Contains("UserCard"))
//                 {
//                     logInResponses++;
//                 }
//                 else if (response.Content.Contains("Ien&#x101;kt Mana Latvija.lv"))
//                 {
//                     logOutResponses++;
//                 }
//
//                 Assert.IsNotNull(response.Content);
//             }
//             timer.Stop();
//             Console.WriteLine(
//                 "Test values. \nTotal responses: " + totalCount
//                 + ", \nTotal performance time: " + timer.Elapsed.TotalSeconds.ToString("0.0") + " sec"
//                 + ", \nResponse time:"
//                 + "  \n    First: " + responseTimes[0].ToString("0.00") + " sec"
//                 + ", \n    Second: " + responseTimes[1].ToString("0.00") + " sec"
//                 + ", \n    Average: " + (timer.Elapsed.TotalSeconds / totalCount).ToString("0.00") + " sec"
//                 + ", \n    p95: " + (StatisticsHelper.Percentile(responseTimes, 0.95)).ToString("0.00") + " sec"
//                 + ", \nTransfer size rate: " + (totalDataReceived / 1024 / timer.Elapsed.TotalSeconds).ToString("0.0") + " kB/sec"
//                 + ", \nResponse rate: " + (totalCount / timer.Elapsed.TotalSeconds).ToString("0.0") + " responses/sec"
//                 + ", \nSuccess response rate: " + (double)successResponses / (double)totalCount * 100 + " %"
//                 + ", \nLogged-in  response rate: " + (double)logInResponses / (double)totalCount * 100 + " %"
//                 + ", \nLogged-out response rate: " + (double)logOutResponses / (double)totalCount * 100 + " %"
//             );
//         }
//     }
// }
