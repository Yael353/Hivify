using Ansjon.Core.Aggregates.Feeds;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Feeds.Commands.CreateFeed;
using Ansjon.UseCases.Feeds.Commands.DeleteFeed;
using Ansjon.UseCases.Feeds.Commands.UpdateFeed;
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

            services.AddScoped<ICommandHandler<CreateFeedCommand, FeedID>, CreateFeedCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateFeedCommand, FeedID>, UpdateFeedCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteFeedCommand, bool>, DeleteFeedCommandHandler>();
            services.AddScoped<ViewFeeds>();
            services.AddValidatorsFromAssemblyContaining<CreateFeedCommandValidator>();
            return services;
        }
    }
}