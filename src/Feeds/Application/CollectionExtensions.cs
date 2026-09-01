using Feeds.Application.Commands.CreateFeed;
using Feeds.Application.Commands.DeleteFeed;
using Feeds.Application.Commands.UpdateFeed;
using Feeds.Application.DTOs;
using Feeds.Application.Queries.GetFeeds;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Messaging;

namespace Feeds.Application;


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
            services.AddScoped<CreateFeedCommandValidator>();
            return services;
        }
    }
}