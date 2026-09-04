using BuildingBlocks.ApplicationPorts.Storage;
using BuildingBlocks.Infrastructure.Storage.CloudinaryStorage;
using Microsoft.Extensions.DependencyInjection;
namespace BuildingBlocks.Infrastructure.Storage;

public static class DiCollectionExtensions
{
    public static IServiceCollection AddStorageServices(this IServiceCollection services)
    {


        services.AddSingleton<IFileStorage, CloudinaryFileStorage>();

        return services;
    }
}