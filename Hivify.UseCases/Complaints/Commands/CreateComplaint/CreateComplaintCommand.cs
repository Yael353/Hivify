using Hivify.Core.Aggregates.Complaints;
using Hivify.UseCases.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hivify.UseCases.Complaints.Commands.CreateComplaint
{
    public sealed record CreateComplaintCommand(
    ComplaintCategory Category,
    string Title,
    string Description,
    string? ImageUrl
) : ICommand<Guid>;
}
