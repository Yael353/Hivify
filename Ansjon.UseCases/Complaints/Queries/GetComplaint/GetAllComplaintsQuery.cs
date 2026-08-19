using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Complaints.DTOs;


namespace Ansjon.UseCases.Complaints.Queries.GetComplaint
{
    public sealed record GetAllComplaintsQuery() : IQuery<IReadOnlyList<ComplaintListItemDto>>;
}
