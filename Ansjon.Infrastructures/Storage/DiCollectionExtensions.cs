using Ansjon.Infrastructures.Storage.CloudinaryStorage;
using Ansjon.UseCases.Abstractions.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.Infrastructures.Storage;

public static class DiCollectionExtensions
{
    public static IServiceCollection AddStorageServices(this IServiceCollection services)
    {


        services.AddSingleton<IFileStorage, CloudinaryFileStorage>();

        return services;
    }
}