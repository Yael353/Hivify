using Ansjon.UseCases.Common.Validators;
using Ansjon.UseCases.Feeds.Handlers;
using Ansjon.UseCases.Feeds.Queries;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Feeds;


public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFeedServices()
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
}