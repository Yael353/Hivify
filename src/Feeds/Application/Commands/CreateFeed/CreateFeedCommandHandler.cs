using BuildingBlocks.ApplicationPorts.Context;
using Feeds.Application.Contracts;
using Feeds.Domain.Feeds;
using FluentValidation;
using SharedKernel.Messaging;
using SharedKernel.ValuesObjects;
namespace Feeds.Application.Commands.CreateFeed;

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