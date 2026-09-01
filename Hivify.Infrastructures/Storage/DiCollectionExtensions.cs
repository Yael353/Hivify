using Hivify.Infrastructures.Storage.CloudinaryStorage;
using Hivify.UseCases.Abstractions.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Hivify.Infrastructures.Storage;

public static class DiCollectionExtensions
{
    public static IServiceCollection AddStorageServices(this IServiceCollection services)
    {


        services.AddSingleton<IFileStorage, CloudinaryFileStorage>();

        return services;
    }
}