using Complaints.Domain;
using SharedKernel.Messaging;

namespace Hivify.UseCases.Complaints.Commands.UpdateComplaintStatus;

public sealed record UpdateComplaintStatusCommand(
    Guid ComplaintId,
    ComplaintStatus Status,
    string? AdminComment
) : ICommand<bool>;