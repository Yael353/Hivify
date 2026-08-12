using Ansjon.Core.Aggregates.Feeds;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Feeds.Commands.CreateFeed;


public sealed record CreateFeedCommand(string Title, string Content) : ICommand<FeedID>;