using Ansjon.Core.Aggregates.Association.Staff;
using Ansjon.Core.Aggregates.Feeds;
using Ansjon.Core.ValuesObjects;
using Ansjon.UseCases.Communications.InterFaces;
using FluentValidation;

public class CreateFeed
{
    private readonly IFeedRepo _communicationRepo;
    private readonly ICurrentUser _currentUser;
    private readonly IValidator<CreateFeedDto> _validator;

    public CreateFeed(
        IFeedRepo communicationRepo,
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

        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can create feeds.");
        }

        var userId = await _currentUser.GetUserIdAsync();

        var feed = Feed.CreateFeed(
            new StaffMemberID(userId),
            StaffRole.Admin,
            new Title(input.Title),
            new Description(input.Content));

        await _communicationRepo.CreateFeedAsync(feed);

        return feed.Id.Value;
    }

}
