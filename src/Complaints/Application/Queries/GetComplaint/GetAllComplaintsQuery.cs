using Complaints.Application.Contracts;
using SharedKernel.Messaging;


namespace Complaints.Application.Queries.GetComplaint
{
    public sealed record GetAllComplaintsQuery() : IQuery<IReadOnlyList<ComplaintListItem>>;
}
