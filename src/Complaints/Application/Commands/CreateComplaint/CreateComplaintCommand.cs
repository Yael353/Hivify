using Complaints.Domain;
using SharedKernel.Messaging;

namespace Complaints.Application.Commands.CreateComplaint
{
    public sealed record CreateComplaintCommand(
    ComplaintCategory Category,
    string Title,
    string Description,
    string? ImageUrl
) : ICommand<Guid>;
}
