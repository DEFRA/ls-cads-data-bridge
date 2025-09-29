namespace Cads.Infrastructure.Storage.Clients;

public class ExternalStorageClient : IStorageClient
{
    public string ClientName => GetType().Name;
}