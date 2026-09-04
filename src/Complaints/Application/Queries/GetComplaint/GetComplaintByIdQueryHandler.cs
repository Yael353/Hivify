using Complaints.Application.Contracts;
using Hivify.Core.Aggregates.Complaints;
using Hivify.Core.SharedKernel.ValuesObjects;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;

namespace Hivify.UseCases.Complaints.Queries.GetComplaint;

public sealed class GetComplaintByIdQueryHandler
    : IQueryHandler<GetComplaintByIdQuery, ComplaintListItem?>
{
    private readonly IComplaintRepo _complaintRepository;

    public GetComplaintByIdQueryHandler(IComplaintRepo complaintRepository)
    {
        _complaintRepository = complaintRepository;
    }

    public async Task<ComplaintListItem?> Handle(
        GetComplaintByIdQuery query,
        CancellationToken cancellationToken)
    {
        var complaint = await _complaintRepository.GetComplaintByIdAsync(
            new ComplaintID(query.ComplaintId),
            cancellationToken);

        if (complaint == null) return null;

        return new ComplaintListItemDto(
            complaint.Id.Value,
            complaint.Title.Value,
            complaint.Description.Value,
            complaint.Category,
            complaint.Status,
            complaint.CreatedDate,
            complaint.ImageUrl,
            complaint.AdminComment,
            complaint.UserId.Value.ToString()
        );
    }
}