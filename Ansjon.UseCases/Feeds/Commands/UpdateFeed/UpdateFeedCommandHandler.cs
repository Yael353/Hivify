using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using FluentValidation;

namespace Ansjon.UseCases.Feeds.Commands.UpdateFeed;

public sealed class UpdateFeedCommandHandler
    : ICommandHandler<UpdateFeedCommand, FeedID>
{
    private readonly IFeedRepo _feedRepository;
    private readonly ICurrentUser _currentUser;
    private readonly IValidator<UpdateFeedCommand> _validator;

    public UpdateFeedCommandHandler(
        IFeedRepo feedRepository,
        ICurrentUser currentUser,
        IValidator<UpdateFeedCommand> validator)
    {
        _feedRepository = feedRepository;
        _currentUser = currentUser;
        _validator = validator;
    }

    public async Task<FeedID> Handle(
        UpdateFeedCommand command,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        await _validator.ValidateAndThrowAsync(
            command,
            cancellationToken);

        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can update feeds.");
        }

        var feed = await _feedRepository.GetByIdAsync(command.FeedId);

        if (feed is null)
        {
            throw new KeyNotFoundException(
                $"Feed {command.FeedId} was not found.");
        }

        var role = MemberRole.GeneralMember;

        feed.Update(
            new Title(command.Title.Trim()),
            new Description(command.Content.Trim()),
            role);

        await _feedRepository.UpdateFeedAsync(feed);

        return feed.Id;
    }
}