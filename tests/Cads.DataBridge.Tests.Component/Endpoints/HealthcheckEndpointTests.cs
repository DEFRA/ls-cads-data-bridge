using Amazon.S3.Model;
using FluentAssertions;
using Moq;
using System.Net;

namespace Cads.DataBridge.Tests.Component.Endpoints;

public class HealthcheckEndpointTests(AppTestFixture appTestFixture) : IClassFixture<AppTestFixture>
{
    private readonly AppTestFixture _appTestFixture = appTestFixture;

    [Fact]
    public async Task GivenValidHealthCheckRequest_ShouldSucceed()
    {
        _appTestFixture.AppWebApplicationFactory.AmazonS3Mock!
            .Setup(x => x.ListObjectsV2Async(It.IsAny<ListObjectsV2Request>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ListObjectsV2Response { HttpStatusCode = HttpStatusCode.OK });

        var response = await _appTestFixture.HttpClient.GetAsync("health");
        var responseBody = await response.Content.ReadAsStringAsync();

        response.EnsureSuccessStatusCode();
        responseBody.Should().NotBeNullOrEmpty().And.Contain("\"status\": \"Healthy\"");
        responseBody.Should().NotContain("\"status\": \"Degraded\"");
        responseBody.Should().NotContain("\"status\": \"Unhealthy\"");
    }
}