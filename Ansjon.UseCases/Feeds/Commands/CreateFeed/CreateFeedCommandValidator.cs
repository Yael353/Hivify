using FluentValidation;

namespace Ansjon.UseCases.Feeds.Commands.CreateFeed
{
    public sealed class CreateFeedCommandValidator : AbstractValidator<CreateFeedCommand>
    {
        public CreateFeedCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Content)
                .NotEmpty();
        }
    }
}
