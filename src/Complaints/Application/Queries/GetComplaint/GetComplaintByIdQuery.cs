using BuildingBlocks.ApplicationPorts.Messeging;
using Complaints.Application.Contracts;

namespace Complaints.Application.Queries.GetComplaint;

public sealed record GetComplaintByIdQuery(Guid ComplaintId) : IQuery<ComplaintListItem?>;