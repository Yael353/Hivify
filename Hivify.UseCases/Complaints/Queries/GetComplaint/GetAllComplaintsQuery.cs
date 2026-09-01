using Hivify.UseCases.Abstractions.Messaging;
using Hivify.UseCases.Complaints.DTOs;


namespace Hivify.UseCases.Complaints.Queries.GetComplaint
{
    public sealed record GetAllComplaintsQuery() : IQuery<IReadOnlyList<ComplaintListItemDto>>;
}
