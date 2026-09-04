using Complaints.Domain;
using SharedKernel.Messaging;

namespace Hivify.UseCases.Complaints.Commands.CreateComplaint
{
    public sealed record CreateComplaintCommand(
    ComplaintCategory Category,
    string Title,
    string Description,
    string? ImageUrl
) : ICommand<Guid>;
}
