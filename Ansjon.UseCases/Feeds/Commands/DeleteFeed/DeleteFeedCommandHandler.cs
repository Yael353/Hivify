using Ansjon.Core.Aggregates.Feeds;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Feeds.Commands.DeleteFeed;

public sealed class DeleteFeedCommandHandler
    : ICommandHandler<DeleteFeedCommand, bool>
{
    private readonly IFeedRepo _feedRepository;
    private readonly ICurrentUser _currentUser;

    public DeleteFeedCommandHandler(
        IFeedRepo feedRepository,
        ICurrentUser currentUser)
    {
        _feedRepository = feedRepository;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(
        DeleteFeedCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can delete feeds.");
        }

        var feedId = new FeedID(command.FeedId);

        var feed = await _feedRepository.GetByIdAsync(
            feedId,
            cancellationToken);

        if (feed is null)
        {
            throw new KeyNotFoundException(
                $"Feed {command.FeedId} was not found.");
        }

        feed.Delete();

        await _feedRepository.UpdateFeedAsync(
            feed,
            cancellationToken);

        return true;
    }
}