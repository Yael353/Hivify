using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Presistence;

namespace Ansjon.UseCases.Admin.Commands;

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
        var role = MemberRole.GeneralMember;


        // Domain layer authorization + business rules
        feed.Delete(role);


        await _communicationRepo.UpdateFeedAsync(feed);
    }
}