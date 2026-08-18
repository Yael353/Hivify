using Ansjon.UseCases.Abstractions.Messaging;
using Ansjon.UseCases.Complaints.DTOs;

namespace Ansjon.UseCases.Complaints.Queries;

public sealed record GetMyComplaintsQuery() : IQuery<IReadOnlyList<ComplaintListItemDto>>;