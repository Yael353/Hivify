using Ansjon.UseCases.Communications.FeedUseCases;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Communications;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFeedServices(
        this IServiceCollection services)
    {
        services.AddScoped<CreateFeed>();
        services.AddScoped<UpdateFeed>();
        services.AddScoped<DeleteFeed>();
        services.AddScoped<ViewFeeds>();

        return services;
    }
}