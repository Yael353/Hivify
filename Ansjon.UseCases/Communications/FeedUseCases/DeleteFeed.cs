using Ansjon.Core.Aggregates.Associations.Staff;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Abstractions.Services;

namespace Ansjon.UseCases.Communications.FeedUseCases;

public class DeleteFeed
{
    private readonly IFeedRepo _communicationRepo;
    private readonly ICurrentUser _currentUser;

    public DeleteFeed(
        IFeedRepo communicationRepo,
        ICurrentUser currentUser)
    {
        _communicationRepo = communicationRepo;
        _currentUser = currentUser;
    }

    public async Task DeleteFeedAsync(Guid feedId)
    {
        // Application layer authorization
        if (!await _currentUser.IsInRoleAsync("Admin"))
        {
            throw new UnauthorizedAccessException(
                "Only administrators can delete feeds.");
        }


        var feed = await _communicationRepo.GetByIdAsync(feedId);

        if (feed == null)
        {
            throw new KeyNotFoundException(
                $"Feed {feedId} not found.");
        }


        // Get role for domain validation
        var role = StaffRole.Admin;


        // Domain layer authorization + business rules
        feed.Delete(role);


        await _communicationRepo.UpdateFeedAsync(feed);
    }
}