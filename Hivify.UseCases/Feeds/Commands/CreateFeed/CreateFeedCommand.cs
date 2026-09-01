using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Feeds.Commands.CreateFeed;


public sealed record CreateFeedCommand(string Title, string Content) : ICommand<Guid>;