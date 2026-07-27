using Ansjon.Core.AppValues;
using Ansjon.UseCases.Communications.DTOs.FeedDtos;
using Ansjon.UseCases.Communications.InterFaces;
using FluentValidation;

namespace Ansjon.UseCases.Communications.FeedUseCases
{
    public class UpdateFeed
    {
        private readonly IFeedRepo _communicationRepo;
        private readonly IValidator<UpdateFeedDto> _validator;
        public UpdateFeed(IFeedRepo communicationRepo, IValidator<UpdateFeedDto> validator)
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
            existing.Update(new Title(input.Title),
        new Description(input.Content));

            await _communicationRepo.UpdateFeedAsync(existing);
        }
    }
}
