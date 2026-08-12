using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using FluentValidation;

namespace Ansjon.UseCases.Feeds.Commands.CreateFeed;

public sealed class CreateFeedCommandHandler : ICommandHandler<CreateFeedCommand, Guid>
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

    public async Task<Guid> Handle(
        CreateFeedCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        // 1. Validate the application request
        await _validator.ValidateAndThrowAsync(
            command,
            cancellationToken);

        // 2. Application-layer authorization
        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can create feeds.");
        }

        // 3. Get authenticated Identity user
        var userId = await _currentUser.GetUserIdAsync();

        // 4. Convert application data into domain value objects
        var feed = Feed.CreateFeed(
            new MemberID(userId),
            MemberRole.GeneralMember,
            new Title(command.Title),
            new Description(command.Content));

        // 5. Persist the domain aggregate
        await _feedRepository.CreateFeedAsync(
            feed,
            cancellationToken);

        // 6. Return primitive ID to the application/UI boundary
        return feed.Id.Value;
    }
}