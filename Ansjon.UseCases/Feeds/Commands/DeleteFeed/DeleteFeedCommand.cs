using Ansjon.Core.Aggregates.Feeds;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Feeds.Commands.DeleteFeed;

public sealed record DeleteFeedCommand(FeedID FeedId) : ICommand<bool>;