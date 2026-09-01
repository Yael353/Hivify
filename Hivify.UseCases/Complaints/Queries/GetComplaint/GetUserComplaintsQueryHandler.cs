using Hivify.Core.SharedKernel.ValuesObjects;
using Hivify.UseCases.Abstractions.Context;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;
using Hivify.UseCases.Complaints.DTOs;

namespace Hivify.UseCases.Complaints.Queries.GetComplaint;

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
                c.ImageUrl,
                 c.AdminComment))
            .ToList();
    }
}