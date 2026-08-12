using Ansjon.Core.Aggregates.Associations.Members;
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
        // Application-layer authorization
        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can delete feeds.");
        }

        var feed = await _feedRepository.GetByIdAsync(
            command.FeedId,
            cancellationToken);

        if (feed is null)
        {
            throw new KeyNotFoundException(
                $"Feed {command.FeedId.Value} was not found.");
        }

        // Domain operation
        feed.Delete(MemberRole.GeneralMember);

        // Persist the aggregate
        await _feedRepository.UpdateFeedAsync(
            feed,
            cancellationToken);

        return true;
    }
}