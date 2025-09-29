using Cads.Core.Messaging;

namespace Cads.Infrastructure.Messaging.Clients;

public class DataBridgeTopicClient : ITopicClient
{
    public string ClientName => GetType().Name;
}