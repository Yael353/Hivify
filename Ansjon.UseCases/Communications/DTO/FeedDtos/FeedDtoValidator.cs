using FluentValidation;

namespace Ansjon.UseCases.Communications.DTO.FeedDto
{
    public class CreateFeedDtoValidator : AbstractValidator<CreateFeedDto>
    {
        public CreateFeedDtoValidator()
        {
            RuleFor(x => x.Title.Trim())
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Content.Trim())
                .NotEmpty();
        }
    }

    public class UpdateFeedDtoValidator : AbstractValidator<UpdateFeedDto>
    {
        public UpdateFeedDtoValidator()
        {
            RuleFor(x => x.Title.Trim())
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.Content.Trim())
                .NotEmpty();
        }
    }
}
