using Ansjon.Core.Aggregates.Associations;
using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.UseCases.Abstractions.Messaging;

namespace Ansjon.UseCases.Association.Commands.AddStaffMember;

public sealed record AddStaffMemberCommand(
    AssociationID AssociationId,
    string FullName,
    MemberRole Role
) : ICommand<MemberID>;