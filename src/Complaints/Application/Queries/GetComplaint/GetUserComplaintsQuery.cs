using Complaints.Application.Contracts;
using SharedKernel.Messaging;

namespace Hivify.UseCases.Complaints.Queries.GetComplaint;

public sealed record GetUserComplaintsQuery() : IQuery<IReadOnlyList<ComplaintListItem>>;