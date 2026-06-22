using Ansjon.UseCases.Communications.DTO.FeedDto;
using FluentValidation;

namespace Ansjon.UseCases.Communications.FeedUseCases
{
    public class UpdateFeed
    {
        private readonly ICommunicationRepo _communicationRepo;
        private readonly IValidator<UpdateFeedDto> _validator;
        public UpdateFeed(ICommunicationRepo communicationRepo, IValidator<UpdateFeedDto> validator)
        {
            _communicationRepo = communicationRepo;
            _validator = validator;
        }

        public async Task UpdateFeedAsync(Guid id, UpdateFeedDto input)
        {

            await _validator.ValidateAndThrowAsync(input);
            var existing = await _communicationRepo.GetByIdAsync(id);
            if (existing == null)
            {
                throw new KeyNotFoundException(
                    $"Feed {id} not found"
                );
            }
            existing.ChangeTitle(input.Title);
            existing.ChangeContent(input.Content);
            await _communicationRepo.UpdateFeedAsync(existing);
        }
    }
}
