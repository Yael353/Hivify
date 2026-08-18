using Ansjon.Core.SharedKernel.ValuesObjects;
using Ansjon.UseCases.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ansjon.UseCases.Complaints.Commands.CreateComplaint
{
    public sealed record CreateComplaintCommand(
    ComplaintCategory Category,
    string Title,
    string Description,
    string? ImageUrl
) : ICommand<Guid>;
}
