using Ansjon.Core.Aggregates.Associations.Members;
using Ansjon.UseCases.Abstractions.Messaging;

public sealed record AddStaffMemberCommand(
    Guid AssociationId,
    Guid UserId,
    string FullName,
    string Email,
    MemberRole Role) : ICommand<MemberID>;