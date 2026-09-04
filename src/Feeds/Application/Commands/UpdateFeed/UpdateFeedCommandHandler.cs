using Feeds.Application.Contracts;
using Feeds.Domain.Feeds;
using FluentValidation;
using SharedKernel.Messaging;
using SharedKernel.ValuesObjects;

namespace Feeds.Application.Commands.UpdateFeed;

public sealed class UpdateFeedCommandHandler
    : ICommandHandler<UpdateFeedCommand, bool>
{
    private readonly IFeedRepo _feedRepository;
    private readonly IValidator<UpdateFeedCommand> _validator;

    public UpdateFeedCommandHandler(
        IFeedRepo feedRepository,
        IValidator<UpdateFeedCommand> validator)
    {
        _feedRepository = feedRepository;
        _validator = validator;
    }

    public async Task<bool> Handle(
        UpdateFeedCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        await _validator.ValidateAndThrowAsync(
            command,
            cancellationToken);

        var feed = await _feedRepository.GetByIdAsync(
            new FeedID(command.FeedId),
            cancellationToken);

        if (feed is null)
        {
            throw new KeyNotFoundException(
                $"Feed {command.FeedId} was not found.");
        }

        feed.Update(
            new Title(command.Title),
            new Description(command.Content));

        await _feedRepository.UpdateFeedAsync(
            feed,
            cancellationToken);

        return true;
    }
}