using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Complaints.DTOs;

namespace Ansjon.UseCases.Complaints.Queries.GetComplaint;

public sealed class GetUserComplaintsQueryHandler
    : IQueryHandler<GetUserComplaintsQuery, IReadOnlyList<ComplaintListItemDto>>
{
    private readonly IComplaintRepo _complaintRepository;
    private readonly ICurrentUser _currentUser;

    public GetUserComplaintsQueryHandler(IComplaintRepo complaintRepository, ICurrentUser currentUser)
    {
        _complaintRepository = complaintRepository;
        _currentUser = currentUser;
    }

    public async Task<IReadOnlyList<ComplaintListItemDto>> Handle(
        GetUserComplaintsQuery query,
        CancellationToken cancellationToken)
    {
        var userId = await _currentUser.GetUserIdAsync();

        var complaints = await _complaintRepository.GetComplaintsByUserAsync(
            new UserID(userId),
            cancellationToken);

        return complaints
            .OrderByDescending(c => c.CreatedDate)
            .Select(c => new ComplaintListItemDto(
                c.Id.Value,
                c.Title.Value,
                c.Description.Value,
                c.Category,
                c.Status,
                c.CreatedDate,
                c.ImageUrl))
            .ToList();
    }
}