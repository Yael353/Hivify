using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Complaints.DTOs;

namespace Ansjon.UseCases.Complaints.Queries.GetComplaintById;

public sealed record GetComplaintByIdQuery(Guid ComplaintId) : IQuery<ComplaintListItemDto?>;