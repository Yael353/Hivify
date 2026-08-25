using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using FluentValidation;

namespace Ansjon.UseCases.Feeds.Commands.CreateFeed;

public sealed class CreateFeedCommandHandler
    : ICommandHandler<CreateFeedCommand, Guid>
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

        await _validator.ValidateAndThrowAsync(
            command,
            cancellationToken);

        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can create feeds.");
        }

        var userId = await _currentUser.GetUserIdAsync();

        var feed = Feed.CreateFeed(
            new UserID(userId),
            new Title(command.Title),
            new Description(command.Content));

        await _feedRepository.CreateFeedAsync(
            feed,
            cancellationToken);

        return feed.Id.Value;
    }
}