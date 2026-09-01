using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Feeds.Commands.CreateFeed;
using Hivify.UseCases.Feeds.Commands.DeleteFeed;
using Hivify.UseCases.Feeds.Commands.UpdateFeed;
using Hivify.UseCases.Feeds.DTOs;
using Hivify.UseCases.Feeds.Queries.GetFeeds;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Hivify.UseCases.Feeds;


public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddFeedServices()
        {

            services.AddScoped<ICommandHandler<CreateFeedCommand, Guid>, CreateFeedCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateFeedCommand, bool>, UpdateFeedCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteFeedCommand, bool>, DeleteFeedCommandHandler>();
            services.AddScoped<IQueryHandler<GetFeedsQuery, IReadOnlyList<FeedListItemDto>>, GetFeedsQueryHandler>();
            services.AddValidatorsFromAssemblyContaining<CreateFeedCommandValidator>();
            return services;
        }
    }
}