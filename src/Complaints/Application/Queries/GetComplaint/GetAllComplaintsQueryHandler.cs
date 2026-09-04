using Complaints.Application.Contracts;
using SharedKernel.Messaging;


namespace Complaints.Application.Queries.GetComplaint
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
                .Select(c => new ComplaintListItem(
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
