using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Feeds.Commands.CreateFeed;
using Ansjon.UseCases.Feeds.Commands.DeleteFeed;
using Ansjon.UseCases.Feeds.Commands.UpdateFeed;
using Ansjon.UseCases.Feeds.DTOs;
using Ansjon.UseCases.Feeds.Queries.GetFeeds;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Ansjon.UseCases.Feeds;


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