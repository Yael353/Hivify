using Ansjon.Core.Entities;
using Ansjon.UseCases.Communications;
using FluentValidation;

public class CreateFeed
{
    private readonly ICommunicationRepo _communicationRepo;
    private readonly IValidator<CreateFeedDto> _validator;

    public CreateFeed(
        ICommunicationRepo communicationRepo,
        IValidator<CreateFeedDto> validator)
    {
        _communicationRepo = communicationRepo;
        _validator = validator;
    }

    public async Task<Guid> CreateFeedAsync(CreateFeedDto input)
    {
        ArgumentNullException.ThrowIfNull(input);

        await _validator.ValidateAndThrowAsync(input);

        var feed = new Feed(
        input.Title,
        input.Content
        );

        await _communicationRepo.CreateFeedAsync(feed);

        return feed.Id;
    }

}