using Complaints.Application.Contracts;
using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Abstractions.Presistence;


namespace Hivify.UseCases.Complaints.Queries.GetComplaint
{
    public sealed class GetAllComplaintsQueryHandler
        : IQueryHandler<GetAllComplaintsQuery, IReadOnlyList<ComplaintListItem>>
    {
        private readonly IComplaintRepo _complaintRepository;

        public GetAllComplaintsQueryHandler(IComplaintRepo complaintRepository)
        {
            _complaintRepository = complaintRepository;
        }

        public async Task<IReadOnlyList<ComplaintListItem>> Handle(
            GetAllComplaintsQuery query,
            CancellationToken cancellationToken)
        {
            var complaints = await _complaintRepository.GetAllComplaintsAsync(cancellationToken);

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
}
