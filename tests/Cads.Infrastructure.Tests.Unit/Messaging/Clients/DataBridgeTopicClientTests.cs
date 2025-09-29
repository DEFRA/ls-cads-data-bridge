using FluentAssertions;
using Cads.Infrastructure.Messaging.Clients;

namespace Cads.Infrastructure.Tests.Unit.Messaging.Clients;

public class DataBridgeTopicClientTests
{
    [Fact]
    public void ClientName_ReturnsClassName()
    {
        var client = new DataBridgeTopicClient();

        var result = client.ClientName;

        result.Should().Be(nameof(DataBridgeTopicClient));
    }

}