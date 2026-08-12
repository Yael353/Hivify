using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Presistence;
using FluentValidation;

namespace Ansjon.UseCases.Feeds.Commands.CreateFeed;

public sealed class CreateFeedCommandHandler
{
    private readonly IFeedRepo _feedRepository;
    private readonly ICurrentUser _currentUser;
    private readonly IValidator<CreateFeedCommand> _validator;

    public CreateFeedCommandHandler(
        IFeedRepo feedRepository,
        ICurrentUser currentUser,
        IValidator<CreateFeedCommand> validator)
    {
        _feedRepository = feedRepository;
        _currentUser = currentUser;
        _validator = validator;
    }

    public async Task<Guid> HandleAsync(CreateFeedCommand command, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);

        await _validator.ValidateAndThrowAsync(command, cancellationToken);

        // Application authorization
        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can create feeds.");
        }

        var userId = await _currentUser.GetUserIdAsync();

        // Create domain aggregate
        var feed = Feed.CreateFeed(
            new MemberID(userId),
            MemberRole.GeneralMember,
            new Title(command.Title),
            new Description(command.Content));

        // Persist aggregate
        await _feedRepository.CreateFeedAsync(feed);

        return feed.Id.Value;
    }
}