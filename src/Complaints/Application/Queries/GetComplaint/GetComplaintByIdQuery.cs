using Complaints.Application.Contracts;
using SharedKernel.Messaging;

namespace Complaints.Application.Queries.GetComplaint;

public sealed record GetComplaintByIdQuery(Guid ComplaintId) : IQuery<ComplaintListItem?>;