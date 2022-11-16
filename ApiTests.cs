using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using ABCsoft.CatFactNinja.WebAPI.TestLearningTask.Configuration;
using ABCsoft.CatFactNinja.WebAPI.TestLearningTask.Models;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ABCsoft.CatFactNinja.WebAPI.TestLearningTask;

public class ApiTests
{
    private TestSettings _settings;
    private RestClient _client;

    [SetUp]
    public void Setup()
    {
        _settings = new TestSettings();
        _client = new RestClient(_settings.WebApiUrl);
    }

    #region FactTests

    [Test,
     Category("GetFact"),
     Description("Call get fact endpoint no parameters")]
    public void WebApiGet_GetFactNoParameters_ExpectHttpOkResponse()
    {
        // Arrange
        RestRequest request = new RestRequest(_settings.PathFact);

        // Act 
        var act = _client.Execute(request);

        // Assert
        act.StatusCode.Should().Be(HttpStatusCode.OK);
        act.Content.Should().NotBeNullOrEmpty();
    }

    [Test,
     Category("GetFact"),
     Description("Call get fact endpoint with max_length parameter set to 20")]
    public void WebApiGet_GetFactWithMaxLenghtParameterSetTo20_ExpectCorrectFactText()
    {
        // Arrange
        var maxLenght = 20;

        RestRequest request = new RestRequest(_settings.PathFact);
        request.AddQueryParameter(_settings.MaxLenghtParameter, maxLenght);

        // Act 
        var act = _client.Execute(request);
        var fact = JsonSerializer.Deserialize<CatFact>(act.Content);
        // Assert
        act.StatusCode.Should().Be(HttpStatusCode.OK);
        fact.fact.Should().Be("Cats have 3 eyelids.");
        fact.length.Should().Be(maxLenght);
    }

    [Test,
     Category("GetFact"),
     Description("Call get fact endpoint with max_length parameter set to 0")]
    public void WebApiGet_GetFactWithMaxLenghtParameterSetTo0_ExpectEmptyBody()
    {
        // Arrange
        var maxLenght = 0;

        RestRequest request = new RestRequest(_settings.PathFact);
        request.AddQueryParameter(_settings.MaxLenghtParameter, maxLenght);

        // Act 
        var act = _client.Execute(request);
        var fact = JsonSerializer.Deserialize<CatFact>(act.Content);
        // Assert
        act.StatusCode.Should().Be(HttpStatusCode.OK);
        fact.fact.Should().BeNull();
        fact.length.Should().Be(maxLenght);
    }

    #endregion

    #region FactsTests

    [Test,
     Category("GetFacts"),
     Description("Call get fact endpoint no parameters")]
    public void WebApiGet_GetFactsNoParameters_ExpectHttpOkResponse()
    {
        // Arrange
        RestRequest request = new RestRequest(_settings.PathFacts);

        // Act 
        var act = _client.Execute(request);

        // Assert
        act.StatusCode.Should().Be(HttpStatusCode.OK);
        act.Content.Should().NotBeNullOrEmpty();
    }

    [Test,
     Category("GetFacts"),
     Description("Call get fact endpoint no parameters")]
    [TestCase(1)]
    [TestCase(5)]
    [TestCase(100)]
    [TestCase(20)]
    public void WebApiGet_GetFactsWithDifferentLimitParameters_GetExpectedFactCount(int itemCount)
    {
        // Arrange
        RestRequest request = new RestRequest(_settings.PathFacts);
        request.AddQueryParameter("limit", itemCount);

        // Act 
        var act = _client.Execute(request);
        var facts = JsonSerializer.Deserialize<CatFactsResponse>(act.Content);

        // Assert
        act.StatusCode.Should().Be(HttpStatusCode.OK);
        act.Content.Should().NotBeNullOrEmpty();
        facts.data.Count.Should().Be(itemCount);
    }

    [Test,
     Category("GetFacts"),
     Description("Call get fact endpoint with 0 limit")]
    public void WebApiGet_GetFactsWithLimitParameterSetToZero_GetInternalServerError()
    {
        // Arrange
        RestRequest request = new RestRequest(_settings.PathFacts);
        request.AddQueryParameter("limit", 0);

        // Act 
        var act = _client.Execute(request);
        var facts = JsonSerializer.Deserialize<CatFactsResponse>(act.Content);

        // Assert
        act.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }

    [Test,
     Category("GetFacts"),
     Description("Call get fact endpoint no parameters")]
    [TestCase(20)]
    [TestCase(50)]
    [TestCase(100)]
    // [TestCase(3)]
    public void WebApiGet_GetFactsWithDifferentLenghtParameters_GetExpectedFactCount(int maxLenght)
    {
        // Arrange
        var itemCount = 10;
        RestRequest request = new RestRequest(_settings.PathFacts);
        request.AddQueryParameter("limit", itemCount);
        request.AddQueryParameter("max_length", maxLenght);

        // Act 
        var act = _client.Execute(request);

        // JsonSerializerSettings jSettings = new JsonSerializerSettings
        // {
        //     MissingMemberHandling = MissingMemberHandling.Ignore
        //     
        // };

        var facts = JsonSerializer.Deserialize<CatFactsResponse>(act.Content);

        // Assert
        act.StatusCode.Should().Be(HttpStatusCode.OK);
        act.Content.Should().NotBeNullOrEmpty();
        facts.data.TrueForAll(x => x.fact.Length <= maxLenght);
    }

    #endregion

    #region BreedsTests

    [Test,
     Category("GetBreeds"),
     Description("Call get breeds endpoint no parameters")]
    public void WebApiGet_GetBreedsNoParameters_ExpectHttpOkResponse()
    {
        // Arrange
        RestRequest request = new RestRequest(_settings.PathBreeds);

        // Act 
        var act = _client.Execute(request);

        // Assert
        act.StatusCode.Should().Be(HttpStatusCode.OK);
        act.Content.Should().NotBeNullOrEmpty();
    }

    [Test,
     Category("GetBreeds"),
     Description("Call get breeds endpoint no parameters")]
    [TestCase(1)]
    [TestCase(10)]
    [TestCase(20)]
    [TestCase(98)]
    public void WebApiGet_GetBreedsWithDifferentLimitParameters_GetExpectedBreedCount(int limit)
    {
        // Arrange
        RestRequest request = new RestRequest(_settings.PathBreeds);
        request.AddQueryParameter("limit", limit);

        var jOptions = new JsonSerializerOptions
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString |
                             JsonNumberHandling.WriteAsString
        };

        // Act 
        var act = _client.Execute(request);
        var breeds = JsonSerializer.Deserialize<CatBreedsResponse>(act.Content, jOptions);

        // Assert
        act.StatusCode.Should().Be(HttpStatusCode.OK);
        act.Content.Should().NotBeNullOrEmpty();
        breeds.data.Count.Should().Be(limit);
    }

    #endregion
}
