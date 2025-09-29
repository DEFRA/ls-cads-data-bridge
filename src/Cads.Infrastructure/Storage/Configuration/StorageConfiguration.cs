namespace Cads.Infrastructure.Storage.Configuration;

public record StorageConfiguration
{
    public StorageWithCredentialsConfiguration ExternalStorage { get; init; } = new();
}