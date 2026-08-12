using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Presistence;
using FluentValidation;

namespace Ansjon.UseCases.Feeds.Commands.UpdateFeed;

public sealed class UpdateFeedCommandHandler
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

    public async Task HandleAsync(
        UpdateFeedCommand command,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);

        await _validator.ValidateAndThrowAsync(
            command,
            cancellationToken);

        // Application authorization
        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can update feeds.");
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
        feed.Update(
            new Title(command.Title),
            new Description(command.Content),
            role);

        // Persist
        await _feedRepository.UpdateFeedAsync(feed);
    }
}