using BuildingBlocks.ApplicationPorts.Messeging;
using Complaints.Application.Contracts;


namespace Complaints.Application.Queries.GetComplaint
{
    public sealed record GetAllComplaintsQuery() : IQuery<IReadOnlyList<ComplaintListItem>>;
}
