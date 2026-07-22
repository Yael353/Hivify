using Ansjon.Core.Aggregates.Feeds;
using Ansjon.UseCases.Communications.InterFaces;
using FluentValidation;

public class CreateFeed
{
    private readonly ICommunicationRepo _communicationRepo;
    private readonly ICurrentUser _currentUser;
    private readonly IValidator<CreateFeedDto> _validator;

    public CreateFeed(
        ICommunicationRepo communicationRepo,
        ICurrentUser currentUser,
        IValidator<CreateFeedDto> validator)
    {
        _communicationRepo = communicationRepo;
        _currentUser = currentUser;
        _validator = validator;
    }

    public async Task<Guid> CreateFeedAsync(CreateFeedDto input)
    {
        ArgumentNullException.ThrowIfNull(input);

        await _validator.ValidateAndThrowAsync(input);
        var authorId = await _currentUser.GetUserIdAsync();

        var feed = Feed.CreateFeed(
        authorId,
        input.Title,
        input.Content
        );

        await _communicationRepo.CreateFeedAsync(feed);
        return feed.Id;
    }

}
