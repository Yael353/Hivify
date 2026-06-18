using Ansjon.UseCases.Communications.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Communications.FeedUseCases;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFeedServices(
        this IServiceCollection services)
    {
        services.AddScoped<CreateFeed>();
        services.AddScoped<UpdateFeed>();
        services.AddScoped<DeleteFeed>();
        services.AddScoped<ViewFeeds>();
        services.AddValidatorsFromAssemblyContaining<CreateFeedDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateFeedDtoValidator>();
        return services;
    }
}