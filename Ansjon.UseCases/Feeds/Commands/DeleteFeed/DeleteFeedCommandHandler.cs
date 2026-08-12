using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Feeds.Commands.DeleteFeed;

public sealed class DeleteFeedCommandHandler
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

    public async Task HandleAsync(
        DeleteFeedCommand command,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);

        // Application authorization
        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can delete feeds.");
        }

        var feed =
            await _feedRepository.GetByIdAsync(
                command.FeedId);

        if (feed is null)
        {
            throw new KeyNotFoundException(
                $"Feed {command.FeedId} not found.");
        }

        var role = MemberRole.GeneralMember;

        // Domain operation
        feed.Delete(role);

        // Persist
        await _feedRepository.UpdateFeedAsync(feed);
    }
}