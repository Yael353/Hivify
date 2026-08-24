using Ansjon.Core.Aggregates.Complaints;
using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Abstractions.Presistence;
using Ansjon.UseCases.Complaints.DTOs;

namespace Ansjon.UseCases.Complaints.Queries.GetComplaint;

public sealed class GetComplaintByIdQueryHandler
    : IQueryHandler<GetComplaintByIdQuery, ComplaintListItemDto?>
{
    private readonly IComplaintRepo _complaintRepository;

    public GetComplaintByIdQueryHandler(IComplaintRepo complaintRepository)
    {
        _complaintRepository = complaintRepository;
    }

    public async Task<ComplaintListItemDto?> Handle(
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