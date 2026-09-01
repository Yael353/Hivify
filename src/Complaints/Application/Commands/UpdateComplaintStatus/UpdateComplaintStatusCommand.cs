using Hivify.Core.Complaints;
using Hivify.UseCases.Abstractions.Messaging;

namespace Hivify.UseCases.Complaints.Commands.UpdateComplaintStatus;

public sealed record UpdateComplaintStatusCommand(
    Guid ComplaintId,
    ComplaintStatus Status,
    string? AdminComment
) : ICommand<bool>;