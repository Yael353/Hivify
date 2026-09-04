using Complaints.Application.Contracts;
using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Complaints.Queries.GetComplaint;

public sealed record GetComplaintByIdQuery(Guid ComplaintId) : IQuery<ComplaintListItem?>;