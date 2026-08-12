using FluentValidation;

namespace Ansjon.UseCases.Feeds.Commands.UpdateFeed;

public sealed class UpdateFeedCommandValidator
    : AbstractValidator<UpdateFeedCommand>
{
    public UpdateFeedCommandValidator()
    {
        RuleFor(x => x.FeedId)
            .NotEmpty();

        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Content)
            .NotEmpty()
            .MaximumLength(5000);
    }
}