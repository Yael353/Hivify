using Ansjon.Core.Aggregates.Association.Staff;
using Ansjon.Core.ValuesObjects;
using Ansjon.UseCases.Communications.DTOs.FeedDtos;
using Ansjon.UseCases.Communications.InterFaces;
using FluentValidation;

namespace Ansjon.UseCases.Communications.FeedUseCases;

public class UpdateFeed
{
    private readonly IFeedRepo _communicationRepo;
    private readonly ICurrentUser _currentUser;
    private readonly IValidator<UpdateFeedDto> _validator;

    public UpdateFeed(
        IFeedRepo communicationRepo,
        ICurrentUser currentUser,
        IValidator<UpdateFeedDto> validator)
    {
        _communicationRepo = communicationRepo;
        _currentUser = currentUser;
        _validator = validator;
    }

    public async Task UpdateFeedAsync(Guid id, UpdateFeedDto input)
    {
        await _validator.ValidateAndThrowAsync(input);


        // Application layer authorization check
        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can update feeds.");
        }


        var existing = await _communicationRepo.GetByIdAsync(id);

        if (existing == null)
        {
            throw new KeyNotFoundException(
                $"Feed {id} not found");
        }


        var role = StaffRole.Admin;


        // Domain layer business rule check
        existing.Update(
            new Title(input.Title),
            new Description(input.Content),
            role);


        await _communicationRepo.UpdateFeedAsync(existing);
    }
}