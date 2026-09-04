using BuildingBlocks.ApplicationPorts.Messeging;
using Complaints.Domain;

namespace Complaints.Application.Commands.CreateComplaint
{
    public sealed record CreateComplaintCommand(
    ComplaintCategory Category,
    string Title,
    string Description,
    string? ImageUrl
) : ICommand<Guid>;
}
