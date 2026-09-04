using Complaints.Domain;
using SharedKernel.Messaging;

namespace Complaints.Application.Commands.UpdateComplaintStatus;

public sealed record UpdateComplaintStatusCommand(
    Guid ComplaintId,
    ComplaintStatus Status,
    string? AdminComment
) : ICommand<bool>;