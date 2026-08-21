using Ansjon.Core.Aggregates.Complaints;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Complaints.Commands.UpdateComplaintStatus;

public sealed record UpdateComplaintStatusCommand(
    Guid ComplaintId,
    ComplaintStatus Status,
    string? AdminComment
) : ICommand<bool>;