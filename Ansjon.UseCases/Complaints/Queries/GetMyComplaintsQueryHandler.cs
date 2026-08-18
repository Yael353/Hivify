using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Context;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Complaints.DTOs;

namespace Ansjon.UseCases.Complaints.Queries;

public sealed class GetMyComplaintsQueryHandler
    : IQueryHandler<GetMyComplaintsQuery, IReadOnlyList<ComplaintListItemDto>>
{
    private readonly IComplaintRepo _complaintRepository;
    private readonly ICurrentUser _currentUser;

    public GetMyComplaintsQueryHandler(IComplaintRepo complaintRepository, ICurrentUser currentUser)
    {
        _complaintRepository = complaintRepository;
        _currentUser = currentUser;
    }

    public async Task<IReadOnlyList<ComplaintListItemDto>> Handle(
        GetMyComplaintsQuery query,
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